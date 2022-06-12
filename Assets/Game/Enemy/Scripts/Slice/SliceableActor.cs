using BzKovSoft.CharacterSlicer;
using BzKovSoft.ObjectSlicer;
using Game.Enemy.Scripts.Slice.Event;
using Game.Enemy.Scripts.Slice.Interface;
using Game.Project;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Enemy.Scripts.Slice{
	public class SliceableActor : BzSliceableCharacterBase, ISliceableCustom{
		[BoxGroup] [SerializeField] [Range(0.5f, 1.5f)]
		private float sliceDelay = 1.0f;

		[BoxGroup] [SerializeField] [Range(1, 5)]
		private int maxSliceCount = 1;

		public int sliceCount{ private get; set; }

		public ColdDownTimer Timer;

		private void Start(){
			Timer = new ColdDownTimer(sliceDelay);
		}

		public bool TrySlice(Plane plane){
			if(!Timer.CanInvoke() || sliceCount >= maxSliceCount) return false;
			Slice(plane, result => OnActorSliced(plane, result));
			return true;
		}

		private void OnActorSliced(Plane plane, BzSliceTryResult result){
			var sliced = result.sliced;
			if(!sliced) return;
			var objectNeg = result.outObjectNeg;
			var objectPos = result.outObjectPos;
			Destroy(objectNeg.GetComponent<SliceableActor>());
			Destroy(objectPos.GetComponent<SliceableActor>());
			EventBus.Post(new ActorSliced(plane, gameObject, objectNeg, objectPos));
		}
	}
}