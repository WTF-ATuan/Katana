using BzKovSoft.ObjectSlicer.Samples;
using UnityEngine;

namespace Katana.Scripts{
	public class KatanaCollider : MonoBehaviour{
		private Katana _katana;

		private void Start(){
			_katana = GetComponentInParent<Katana>();
		}


		private void OnTriggerEnter(Collider other){
			var enemy = other.GetComponent<Enemy.Scripts.Enemy>();
			var sliceable = other.GetComponent<IBzSliceableNoRepeat>();
			if(sliceable != null)
				Slice(sliceable, other.transform.position);
		}

		private Vector3 normal;
		private Vector3 collisionPoint;

		private void Slice(IBzSliceableNoRepeat sliceableObject, Vector3 objectPosition){
			normal = Vector3.Cross(_katana.MoveDirection, _katana.BladeDirection);
			collisionPoint = GetCollisionPoint(objectPosition);
			var plane = new Plane(normal, collisionPoint);
			sliceableObject.Slice(plane, 0, result => Debug.Log(result.sliced));
		}

		private Vector3 GetCollisionPoint(Vector3 targetPosition){
			var distanceToObject = targetPosition - _katana.OriginPosition;
			var projectDot = Vector3.Project(distanceToObject, _katana.BladeDirection);
			var collisionPoint = _katana.OriginPosition + projectDot;
			return collisionPoint;
		}

		private void OnDrawGizmos(){
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(normal, 0.1f);
			Gizmos.DrawSphere(collisionPoint, 0.1f);
		}
	}
}