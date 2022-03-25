using BzKovSoft.ObjectSlicer;
using UnityEngine;

namespace Game.Enemy.Scripts.Slice.Interface{
	public interface IActorSliced{
		void OnActorSliced(Plane plane , BzSliceTryResult result);
	}
}