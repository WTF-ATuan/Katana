using System;
using BzKovSoft.ObjectSlicer;
using Game.Project;
using Plugins.BzKovSoft.ObjectSlicer;
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

		public void TrySlice(Plane plane, int sliceId, Action<BzSliceTryResult> callBack){
			if(sliceId == 0 && timer.CanInvoke()){
				Slice(plane, callBack);
				timer.Reset();
			}
		}
	}
}