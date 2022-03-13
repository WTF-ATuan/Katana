﻿using System;
using BzKovSoft.ObjectSlicer;
using UnityEngine;

namespace Plugins.BzKovSoft.ObjectSlicer
{
	/// <summary>
	/// Asynchronously sliceable object
	/// </summary>
	public interface ISliceableNoRepeat
	{
		/// <summary>
		/// Start slicing the object
		/// </summary>
		/// <param name="plane">Plane by which you are going to slice</param>
		/// <param name="sliceId">To prevent multiple slice requests you should use sliceId,
		/// you can pass 0 to ignore it</param>
		/// <param name="callBack">Method that will be called when the slice will be done</param>
		void TrySlice(Plane plane, int sliceId, Action<BzSliceTryResult> callBack);
	}
}
