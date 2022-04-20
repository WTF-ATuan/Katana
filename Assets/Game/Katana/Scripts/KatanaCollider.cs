using Game.Enemy.Scripts.Slice.Interface;
using UnityEngine;

namespace Katana.Scripts{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(Collider))]
	public class KatanaCollider : MonoBehaviour{
		private Katana _katana;

		private void Start(){
			_katana = GetComponentInParent<Katana>();
		}


		private void OnTriggerEnter(Collider other){
			var sliceable = other.GetComponent<ISliceableNoRepeat>();
			if(sliceable != null){
				var collisionPoint = other.ClosestPointOnBounds(_katana.bladePosition);
				Slice(sliceable, collisionPoint);
			}
		}

		private void Slice(ISliceableNoRepeat sliceableObject, Vector3 collisionPoint){
			var planeNormalDirection = _katana.bladeNormal;
			var plane = new Plane(planeNormalDirection, collisionPoint);
			sliceableObject.TrySlice(plane);
		}
	}
}