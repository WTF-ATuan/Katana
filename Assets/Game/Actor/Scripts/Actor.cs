using System;
using UnityEngine;

namespace Actor.Scripts{
	public class Actor : MonoBehaviour{

		public void ModifyFaceDirectionAngle(float increasedAngle){
			var checkValue = increasedAngle / 90;
			var isInt = Mathf.Ceil(checkValue) == Mathf.Floor(checkValue);
			if(!isInt) throw new Exception($"{increasedAngle}value is not right increasedAngle");
			var actorTransform = transform;
			var currentDirection = actorTransform.eulerAngles;
			var nextDirection = new Vector3(currentDirection.x, currentDirection.y + increasedAngle, currentDirection.z);
			actorTransform.eulerAngles = nextDirection;
		}
		public float GetCurrentFaceDirectionAngle(){
			var eulerAngles = transform.eulerAngles;
			return eulerAngles.y;
		}
		
		public void Cleave(Katana.Scripts.Katana katana, Vector3 cleaveDirection){
			katana.PlayAnimation(cleaveDirection);
		}
	}
}