using UnityEngine;

namespace Enemy.Scripts{
	public class Enemy : MonoBehaviour{
		private Transform Target{ get; set; }

		public Vector3 MiddlePosition =>
				new(Target.position.x, transform.position.y, transform.position.z);

		public Vector3 TargetPosition =>
				new(Target.position.x, transform.position.y, Target.position.z + 1f);
		
		public void Initialize(Transform targetPoint){
			Target = targetPoint;
		}

		public void SetFaceDirection(Vector3 targetPosition){
			var enemyTransform = transform;
			var targetDirection = (targetPosition - enemyTransform.position).normalized;
			enemyTransform.forward = targetDirection;
		}
	}
}