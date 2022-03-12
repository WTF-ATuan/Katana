using System;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Katana.Scripts{
	public class Katana : MonoBehaviour{
		[SerializeField] private Transform bladePoint;

		public Vector3 BladeDirection => bladePoint.forward;
		public Vector3 BladePosition => bladePoint.position;

		private Animator _animator;

		private void Start(){
			_animator = GetComponentInChildren<Animator>();
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