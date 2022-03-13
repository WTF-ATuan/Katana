using BzKovSoft.ObjectSlicer;
using Plugins.BzKovSoft.ObjectSlicer;
using UnityEngine;

namespace Katana.Scripts{
	public class Slicer{
		public Vector3 PlaneNormal{ get; private set; }
		public float PlaneDistance{ get; private set; }

		public void Slice(Collider sliceCollider, SliceVertex vertex){
			var sliceableObject = sliceCollider.GetComponent<IBzSliceableNoRepeat>();
			if(sliceableObject == null) return;
			var crossDirection = vertex.CrossDirection;
			var collisionPosition = vertex.CollisionPosition;
			var plane = CreatePlane(crossDirection, collisionPosition);
			sliceableObject.Slice(plane, 0, OnSliced);
		}

		private void OnSliced(BzSliceTryResult obj){ }

		public Plane CreatePlane(Vector3 inNormal, Vector3 inPoint){
			var plane = new Plane(inNormal, inPoint);
			PlaneNormal = plane.normal;
			PlaneDistance = plane.distance;
			return plane;
		}
	}
}