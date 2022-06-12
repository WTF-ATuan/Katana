using System;
using UnityEngine;

namespace BzKovSoft.ObjectSlicer.Samples{
	public interface ISliceableNoRepeat{
		void TrySlice(Plane plane, int knifeSliceID,  Action<BzSliceTryResult> callBack);
	}
}