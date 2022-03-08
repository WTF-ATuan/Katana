using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Enemy.Scripts{
	public class Enemy : MonoBehaviour{
		[SerializeField] private float moveSpeed = 0.05f;
		public Vector3 TargetPosition{ get; private set; }

		public void SetTargetPosition(Vector3 position){
			TargetPosition = position;
		}

		public void Move(){
			var position = transform.position;
			var moveDirection = (TargetPosition - position).normalized;
			transform.position += moveDirection * moveSpeed;
		}

		public void SetFaceDirection(){
			var position = transform.position;
			var moveDirection = (TargetPosition - position).normalized;
			transform.forward = moveDirection;
		}

		public float DistanceOfTarget(Vector3 target){
			var position = transform.position;
			var distance = Vector3.Distance(position, target);
			return distance;
		}


		private Vector3 _hitFirstPoint, _hitLastPoint;
		public void TakeDamage(List<Vector3> damagePoints){
			_hitFirstPoint= damagePoints.First();
			_hitLastPoint = damagePoints.Last();
		}

		private void OnDrawGizmos(){
			Gizmos.color = Color.green;
			Gizmos.DrawSphere(_hitFirstPoint , 0.1f);
			Gizmos.DrawSphere(_hitLastPoint , 0.1f);
		}
	}
}