using BzKovSoft.ObjectSlicer;
using Plugins.BzKovSoft.ObjectSlicer;
using UnityEngine;

namespace Katana.Scripts{
	public class Slicer{
		public Vector3 PlaneNormal{ get; private set; }
		public float PlaneDistance{ get; private set; }

		public void Slice(Collider sliceCollider){ }
	}
}