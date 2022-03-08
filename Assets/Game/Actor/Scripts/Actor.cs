using System;
using Katana.Scripts;
using UnityEngine;

namespace Actor.Scripts{
	public class Actor : MonoBehaviour{
		private KatanaPostureState _currentPostureState;

		public void ModifyFaceDirectionAngle(float increasedAngle){
			var checkValue = increasedAngle / 90;
			var isInt = Mathf.Ceil(checkValue) == Mathf.Floor(checkValue);
			if(!isInt) throw new Exception($"{increasedAngle}value is not right increasedAngle");
			var actorTransform = transform;
			var currentDirection = actorTransform.eulerAngles;
			var nextDirection = new Vector3(currentDirection.x, currentDirection.y + increasedAngle, currentDirection.z);
			actorTransform.eulerAngles = nextDirection;
		}

		public void ModifyPostureState(KatanaPostureState state){
			_currentPostureState = state;
		}

		public float GetCurrentFaceDirectionAngle(){
			var eulerAngles = transform.eulerAngles;
			return eulerAngles.y;
		}

		public KatanaPostureState GetCurrentPostureState(){
			return _currentPostureState;
		}
	}
}