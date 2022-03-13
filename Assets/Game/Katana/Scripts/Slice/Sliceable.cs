using System;
using BzKovSoft.ObjectSlicer;
using Game.Katana.Scripts.Slice.Interface;
using Game.Project;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Katana.Scripts{
	public class Sliceable : BzSliceableObjectBase, ISliceableNoRepeat{
		[BoxGroup] [SerializeField] [Range(0.5f, 1.5f)]
		private float sliceDelay = 1.0f;

		private ColdDownTimer timer;

		private void Start(){
			timer = new ColdDownTimer(sliceDelay);
		}

		protected override BzSliceTryData PrepareData(Plane plane){
			var colliders = GetComponentsInChildren<Collider>();
			return new BzSliceTryData{
				componentManager = new StaticComponentManager(gameObject, plane, colliders),
				plane = plane,
			};
		}

		public void TrySlice(Plane plane, Action<BzSliceTryResult> callBack){
			if(!timer.CanInvoke()) return;
			Slice(plane, callBack);
			timer.Reset();
		}
	}
}