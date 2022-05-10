using System;
using BzKovSoft.ObjectSlicer;
using Game.Enemy.Scripts.Slice.Event;
using Game.Enemy.Scripts.Slice.Interface;
using Game.Project;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Enemy.Scripts.Slice{
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

		public bool TrySlice(Plane plane){
			if(!timer.CanInvoke()) return false;
			Slice(plane, x => OnActorSliced(plane, x));
			timer.Reset();
			return true;
		}

		private void OnActorSliced(Plane plane, BzSliceTryResult result){
			var sliced = result.sliced;
			if(!sliced) return;
			var objectNeg = result.outObjectNeg;
			var objectPos = result.outObjectPos;
			EventBus.Post(new ActorSliced(plane, gameObject, objectNeg, objectPos));
		}
	}
}