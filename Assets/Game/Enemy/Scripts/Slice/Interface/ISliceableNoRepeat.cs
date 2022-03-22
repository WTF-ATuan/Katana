using System;
using UnityEngine;

namespace Game.Enemy.Scripts.Slice.Interface
{
	public interface ISliceableNoRepeat
	{
		bool TrySlice(Plane plane);
	}
}
