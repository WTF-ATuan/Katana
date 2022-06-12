using System;
using UnityEngine;

namespace Game.Enemy.Scripts.Slice.Interface
{
	public interface ISliceableCustom
	{
		bool TrySlice(Plane plane);
	}
}
