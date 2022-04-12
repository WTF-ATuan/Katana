using DG.Tweening;
using UnityEngine;

namespace Game.Enemy.Scripts.UseCase{
	public class AutoMoveBehavior : MonoBehaviour{
		public Transform target;
		public float moveSpeed = 3;

		private global::Enemy.Scripts.Enemy enemy;
		
		public void Init(){
			enemy = GetComponent<global::Enemy.Scripts.Enemy>();
			enemy.Initialize(target);
			AutoMove();
		}

		private void AutoMove(){
			var middlePosition = enemy.MiddlePosition;
			var targetPosition = enemy.TargetPosition;
			enemy.SetFaceDirection(middlePosition);
			var moveToMiddle = enemy.transform.DOMove(middlePosition, moveSpeed);
			moveToMiddle.OnComplete(() => {
				enemy.transform.DOMove(targetPosition, moveSpeed);
				enemy.SetFaceDirection(targetPosition);
			});
		}
	}
}