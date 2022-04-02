using System;
using UnityEngine;

namespace Actor.Scripts{
	public class Actor : MonoBehaviour{
		public IMove MoveBehavior;
		public Vector3 Position => transform.position;

		public void Move(){
			if(MoveBehavior is null){
				throw new Exception("MoveBehavior Interface is null");
			}

			var canMove = MoveBehavior.CanMove();
			if(canMove) MoveBehavior.Move();
		}


		//TODO when Katana Animation is Done we use EventBus to Handle 
		public void Cleave(Katana.Scripts.Katana katana, Vector3 cleaveDirection){
			katana.PlayAnimation(cleaveDirection);
		}
	}
}