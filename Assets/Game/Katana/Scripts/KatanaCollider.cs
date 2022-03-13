using BzKovSoft.ObjectSlicer;
using Plugins.BzKovSoft.ObjectSlicer;
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
				Slice(sliceable, other);
		}

		private Vector3 collisionPoint;

		private void Slice(IBzSliceableNoRepeat sliceableObject, Collider other){
			var normal = Vector3.Cross(_katana.BladeMoveDirection, _katana.BladeDirection);
			collisionPoint = other.ClosestPointOnBounds(_katana.BladePosition);
			var plane = new Plane(normal, collisionPoint);
			sliceableObject.Slice(plane, 0, OnSliced);
		}

		private void OnSliced(BzSliceTryResult result){
			var sliced = result.sliced;
			Debug.Log($"sliced = {sliced}");
		}

		private void OnDrawGizmos(){
			if(!Application.isPlaying) return;
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(collisionPoint, 0.1f);
			Gizmos.DrawWireSphere(collisionPoint + _katana.BladeMoveDirection, 0.1f);
			Gizmos.DrawWireSphere(collisionPoint + _katana.BladeDirection, 0.1f);
			Gizmos.DrawWireSphere(collisionPoint + Vector3.Cross(_katana.BladeMoveDirection, _katana.BladeDirection),
				0.1f);
		}
	}
}