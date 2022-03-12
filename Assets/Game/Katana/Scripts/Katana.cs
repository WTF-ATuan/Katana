using System;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Katana.Scripts{
	public class Katana : MonoBehaviour{
		private Transform _katanaModel;

		[ShowInInspector]
		[ReadOnly]
		public Vector3 BladeDirection =>
				_katanaModel.rotation * Vector3.up;

		public Vector3 OriginPosition{
			get{
				var localShifted = _katanaModel.InverseTransformPoint(_katanaModel.position) + Vector3.down;
				return _katanaModel.TransformPoint(localShifted);
			}
		}

		[ShowInInspector]
		[ReadOnly]
		public Vector3 MoveDirection => _katanaModel.transform.position.normalized;

		private Animator _animator;

		private void Start(){
			_animator = GetComponentInChildren<Animator>();
			_katanaModel = GetComponentsInChildren<Transform>()[1];
		}

		public void PlayAnimation(Vector3 direction){
			if(direction == Vector3.left){
				_animator.Play($"Cleave_Left");
			}

			if(direction == Vector3.right){
				_animator.Play($"Cleave_Right");
			}
		}
	}
}