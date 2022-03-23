using System;
using DG.Tweening;
using UnityEngine;

namespace Enemy.Scripts{
	public class AutoMoveBehavior : MonoBehaviour{
		[SerializeField] private Transform targetTransform;

		private Enemy enemy;

		private void Start(){
			enemy = GetComponent<Enemy>();
			enemy.Initialize(targetTransform);
			AutoMove();
		}

		private void AutoMove(){
			var targetPosition = targetTransform.position;
			var moveToMiddle = enemy.transform.DOMoveX(targetPosition.x, 3f);
			moveToMiddle.OnComplete(() => { enemy.transform.DOMoveZ(targetPosition.z, 3f); });
		}
	}
}