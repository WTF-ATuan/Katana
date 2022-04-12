using DG.Tweening;
using UnityEngine;

namespace Game.Enemy.Scripts.UseCase{
	public class AutoMoveBehavior : MonoBehaviour{
		[SerializeField] private Transform target;

		private global::Enemy.Scripts.Enemy enemy;

		private void Start(){
			enemy = GetComponent<global::Enemy.Scripts.Enemy>();
			enemy.Initialize(target);
			AutoMove();
		}

		private void AutoMove(){
			var middlePosition = enemy.MiddlePosition;
			var targetPosition = enemy.TargetPosition;
			enemy.SetFaceDirection(middlePosition);
			var moveToMiddle = enemy.transform.DOMove(middlePosition, 3f);
			moveToMiddle.OnComplete(() => {
				enemy.transform.DOMove(targetPosition, 3f);
				enemy.SetFaceDirection(targetPosition);
			});
		}
	}
}