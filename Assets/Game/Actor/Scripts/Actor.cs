using System;
using UnityEngine;

namespace Actor.Scripts{
	public class Actor : MonoBehaviour{
		public IMove MoveBehavior;
		public Vector3 Position => transform.position;

		private Animator _animator;

		private void Start(){
			_animator = GetComponent<Animator>();
		}

		public void Move(){
			if(MoveBehavior is null){
				throw new Exception("MoveBehavior Interface is null");
			}

			var canMove = MoveBehavior.CanMove();
			if(canMove) MoveBehavior.Move();
		}


		//TODO when Katana Animation is Done we use EventBus to Handle 
		public void Cleave(Vector3 cleaveDirection){
			string triggerName = null;
			if(cleaveDirection == Vector3.up){
				triggerName = "down-top";
			}

			if(cleaveDirection == Vector3.down){
				triggerName = "top-down";
			}

			if(cleaveDirection == Vector3.left){
				triggerName = "right-left";
			}

			if(cleaveDirection == Vector3.right){
				triggerName = "left-right";
			}

			_animator.SetTrigger(triggerName);
		}
	}
}