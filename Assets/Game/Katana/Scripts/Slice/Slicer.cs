using System;
using BzKovSoft.ObjectSlicer;
using Game.Katana.Scripts.Slice.Interface;
using Katana.Scripts;
using UnityEngine;

namespace Game.Katana.Scripts.Slice{
	public class Slicer{
		public void Slice(ISliceableNoRepeat sliceable, SegmentationData data){
			if(sliceable == null){
				throw new NullReferenceException("ISliceableNoRepeat is null");
			}

			var plane = data.Plane;
			sliceable.TrySlice(plane, OnSliced);
		}

		private void OnSliced(BzSliceTryResult result){
			var sliced = result.sliced;
			Debug.Log($"sliced = {sliced}");
		}
	}
}