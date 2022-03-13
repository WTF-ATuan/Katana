using System;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Katana.Scripts{
	public class Katana : MonoBehaviour{
		[SerializeField] private Transform bladePoint;
		[SerializeField] private Transform bladeBottomPoint;
		public Vector3 BladeDirection => bladePoint.forward;
		public Vector3 BladePosition => bladePoint.position;

		public Vector3 BladeMoveDirection => (_position - _previousPosition).normalized;

		private Vector3 _position, _previousPosition;

		private Animator _animator;

		private void Start(){
			_animator = GetComponentInChildren<Animator>();
		}

		private void Update(){
			_previousPosition = _position;
			_position = bladeBottomPoint.position;
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