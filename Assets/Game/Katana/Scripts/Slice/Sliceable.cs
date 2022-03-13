using BzKovSoft.ObjectSlicer;
using UnityEngine;

namespace Katana.Scripts{
	public class Sliceable : BzSliceableObjectBase{
		protected override BzSliceTryData PrepareData(Plane plane)
		{
			var colliders = GetComponentsInChildren<Collider>();
			return new BzSliceTryData{
				componentManager = new StaticComponentManager(gameObject, plane, colliders),
				plane = plane,
			};
		}
	}
}