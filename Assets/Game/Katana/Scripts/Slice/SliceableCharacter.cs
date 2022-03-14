using System;
using BzKovSoft.ObjectSlicer;
using Game.Katana.Scripts.Slice.Interface;
using Game.Project;
using UnityEngine;

namespace Game.Katana.Scripts.Slice{
	public class SliceableCharacter : ISliceableNoRepeat{
		private ColdDownTimer _timer;
		
		
		
		public void TrySlice(Plane plane, Action<BzSliceTryResult> callBack){
			throw new NotImplementedException();
		}
	}
}