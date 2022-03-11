using System;
using System.Linq;
using UnityEngine;

namespace Katana.Scripts{
	public class Katana : MonoBehaviour{
		private Animator _animator;

		private void Start(){
			_animator = GetComponentInChildren<Animator>();
		}

		public void SetFaceToTarget(Vector2 targetPosition){
			var katanaTransform = transform;
			var faceDirection = (Vector2)katanaTransform.position.normalized
								- targetPosition * -1;
			katanaTransform.up = faceDirection;
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