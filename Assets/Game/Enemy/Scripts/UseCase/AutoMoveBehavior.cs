using DG.Tweening;
using UnityEngine;

namespace Game.Enemy.Scripts.UseCase{
	public class AutoMoveBehavior : MonoBehaviour{
		public Transform target;
		public float moveSpeed = 3;

		private global::Enemy.Scripts.Enemy _enemy;
		private Rigidbody _rigidbody;

		public void Init(){
			_enemy = GetComponent<global::Enemy.Scripts.Enemy>();
			_rigidbody = GetComponent<Rigidbody>();
			_enemy.Initialize(target);
			AutoMove();
		}

		private void AutoMove(){
			var middlePosition = _enemy.MiddlePosition;
			var targetPosition = _enemy.TargetPosition;
			_enemy.SetFaceDirection(middlePosition);
			var moveToMiddle = _rigidbody.DOMove(middlePosition, moveSpeed);
			moveToMiddle.OnComplete(() => {
				_rigidbody.DOMove(targetPosition, moveSpeed);
				_enemy.SetFaceDirection(targetPosition);
			});
		}
	}
}