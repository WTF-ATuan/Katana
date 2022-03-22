using BzKovSoft.CharacterSlicer;
using BzKovSoft.ObjectSlicer;
using Game.Enemy.Scripts.Slice.Interface;
using Game.Project;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Enemy.Scripts.Slice{
	public class SliceableActor : BzSliceableCharacterBase, ISliceableNoRepeat{
		[BoxGroup] [SerializeField] [Range(0.5f, 1.5f)]
		private float sliceDelay = 1.0f;

		[BoxGroup] [SerializeField] [Range(1, 5)]
		private int maxSliceCount = 1;

		private int sliceCount;

		private ColdDownTimer timer;

		private void Start(){
			timer = new ColdDownTimer(sliceDelay);
		}

		public bool TrySlice(Plane plane){
			if(!timer.CanInvoke() || sliceCount >= maxSliceCount) return false;
			Slice(plane, result => OnActorSliced(plane, result));
			sliceCount++;
			timer.Reset();
			return true;
		}

		private void OnActorSliced(Plane plane, BzSliceTryResult result){
			var sliced = result.sliced;
			if(!sliced) return;
			var posRig = result.outObjectPos.GetComponent<Rigidbody>();
			posRig.AddForce((plane.normal + -posRig.transform.forward) * 2, ForceMode.Impulse);
		}
	}

	public interface IActorSliced{
		void OnActorSliced(Plane plane , BzSliceTryResult result);
	}
}