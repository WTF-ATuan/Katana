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
				Slice(sliceable, other);
		}

		private Vector3 collisionPoint;

		private void Slice(IBzSliceableNoRepeat sliceableObject, Collider other){
			var normal = Vector3.Cross(_katana.BladePosition, _katana.BladeDirection);
			Debug.Log($"normal = {normal}");
			collisionPoint = other.ClosestPointOnBounds(_katana.BladePosition);
			var plane = new Plane(normal, collisionPoint);
			sliceableObject.Slice(plane, 0, result => Debug.Log(result.sliced));
		}

		private void OnDrawGizmos(){
			Gizmos.color = Color.green;
			Gizmos.DrawSphere(collisionPoint, 0.1f);
		}
	}
}