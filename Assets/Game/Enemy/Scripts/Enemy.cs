using System;
using UnityEngine;

namespace Enemy.Scripts{
	public class Enemy : MonoBehaviour{
		public Transform TargetTransform{ get; private set; }

		public float MainRoadDistance{ get; private set; }
		public float MiddlePointDistance{ get; private set; }

		public float TargetDistance{ get; private set; }

		public void ConditionDistance(){
			if(!TargetTransform) throw new NullReferenceException("Target is Null");
			var position = transform.position;
			var targetPosition = TargetTransform.position;
			var normal = targetPosition - position;
			TargetDistance = Vector3.Distance(targetPosition, position);
			MainRoadDistance = normal.x;
			MiddlePointDistance = normal.z;
		}
	}
}