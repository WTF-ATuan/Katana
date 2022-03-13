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
			var sliceable = other.GetComponent<ISliceableNoRepeat>();
			if(sliceable != null)
				Slice(sliceable, other);
		}

		private Vector3 collisionPoint;

		private void Slice(ISliceableNoRepeat sliceableObject, Collider other){
			var planeNormalDirection = _katana.BladePlaneNormal;
			collisionPoint = other.ClosestPointOnBounds(_katana.BladePosition);
			var plane = new Plane(planeNormalDirection, collisionPoint);
			sliceableObject.TrySlice(plane, 0, OnSliced);
		}

		private void OnSliced(BzSliceTryResult result){
			var sliced = result.sliced;
			Debug.Log($"sliced = {sliced}");
		}

		private void OnDrawGizmos(){
			if(!Application.isPlaying) return;
			Gizmos.color = Color.red;
		}
	}
}