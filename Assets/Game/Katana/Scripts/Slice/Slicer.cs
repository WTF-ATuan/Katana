using System;
using BzKovSoft.ObjectSlicer;
using Game.Katana.Scripts.Slice.Interface;
using Katana.Scripts;
using UnityEngine;

namespace Game.Katana.Scripts.Slice{
	public class Slicer{
		public Plane CurrentSlicePlane{ get; private set; }

		public void Slice(ISliceableNoRepeat sliceable, SegmentationData data){
			if(sliceable == null){
				throw new NullReferenceException("ISliceableNoRepeat is null");
			}

			CurrentSlicePlane = data.Plane;
			sliceable.TrySlice(CurrentSlicePlane, OnSliced);
		}

		public Vector3 DirectionOfPlane(Vector3 position){
			if(CurrentSlicePlane.Equals(default)) return Vector3.zero;
			var isPositiveSide = CurrentSlicePlane.GetSide(position);
			return isPositiveSide ? Vector3.up : Vector3.down;
		}

		private void OnSliced(BzSliceTryResult result){
			var sliced = result.sliced;
			Debug.Log($"sliced = {sliced}");
		}
	}
}