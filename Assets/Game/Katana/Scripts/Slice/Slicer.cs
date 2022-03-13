using BzKovSoft.ObjectSlicer;
using Game.Katana.Scripts.Slice.Interface;
using UnityEngine;

namespace Katana.Scripts{
	public class Slicer{
		public void Slice(Collider sliceableCollider, SegmentationData data){
			var sliceable = sliceableCollider.GetComponent<ISliceableNoRepeat>();
			if(sliceable == null) return;
			var plane = data.Plane;
			sliceable.TrySlice(plane, OnSliced);
		}

		private void OnSliced(BzSliceTryResult result){
			var sliced = result.sliced;
			Debug.Log($"sliced = {sliced}");
		}
	}
}