using System;
using System.Linq;
using UnityEngine;

namespace Katana.Scripts{
	public class Katana : MonoBehaviour{
		public Vector3 BladeDirection => transform.eulerAngles;
		public Vector3 MoveDirection => (_position - _previousPosition).normalized;

		private Animator _animator;

		private Vector3 _previousPosition;
		private Vector3 _position;

		private void Update(){
			_previousPosition = _position;
			_position = transform.position;
		}

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