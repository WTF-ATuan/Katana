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
			_rigidbody = GetComponentInChildren<Rigidbody>();
			_enemy.Initialize(target);
			AutoMove();
		}

		private void AutoMove(){
			var targetPosition = _enemy.TargetPosition;
			_rigidbody.DOMove(targetPosition, moveSpeed);
			_enemy.SetFaceDirection(targetPosition);
		}
	}
}