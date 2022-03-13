using System;
using BzKovSoft.ObjectSlicer;
using UnityEngine;

namespace Game.Katana.Scripts.Slice.Interface
{
	public interface ISliceableNoRepeat
	{
		void TrySlice(Plane plane, Action<BzSliceTryResult> callBack);
	}
}
