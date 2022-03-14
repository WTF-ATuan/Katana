﻿using System;
using BzKovSoft.CharacterSlicer;
using BzKovSoft.ObjectSlicer;
using Game.Katana.Scripts.Slice.Interface;
using Game.Project;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Katana.Scripts.Slice{
	public class SliceableCharacter : BzSliceableCharacterBase, ISliceableNoRepeat{
		[BoxGroup] [SerializeField] [Range(0.5f, 1.5f)]
		private float sliceDelay = 1.0f;

		private ColdDownTimer timer;

		private void Start(){
			timer = new ColdDownTimer(sliceDelay);
		}

		public void TrySlice(Plane plane, Action<BzSliceTryResult> callBack){
			if(!timer.CanInvoke()) return;
			Slice(plane, callBack);
			timer.Reset();
		}
	}
}