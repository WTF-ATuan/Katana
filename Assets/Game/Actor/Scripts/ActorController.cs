using System;
using System.Linq;
using Project;
using Project.Gesture.Event;
using UnityEngine;

namespace Actor.Scripts{
	public class ActorController : MonoBehaviour{
		private Actor _actor;
		private IMove _moveBehavior;

		//TODO Gesture should be Project folder with other gesture scripts
		private readonly GestureCalculator _gestureCalculator = new();

		private float _contactTime;

		private void Start(){
			InitActor();
			EventHandle();
		}

		private void InitActor(){
			_actor = GetComponent<Actor>();
			_moveBehavior = GetComponent<IMove>();
			_actor.MoveBehavior = _moveBehavior;
		}

		private void EventHandle(){
			EventBus.Subscribe<GestureDetected>(OnGestureDetected);
		}

		private void Update(){
			if(_moveBehavior != null){
				_actor.Move();
			}
		}

		//TODO Gesture should be Project folder with other gesture scripts
		private void OnGestureDetected(GestureDetected obj){
			var gestureName = obj.GestureName;
			var points = obj.Points;
			if(gestureName.Equals("line")){
				var firstPoint = points.First();
				var lastPoint = points.Last();
				var lineDirection = _gestureCalculator.CalculateLineDirection(firstPoint, lastPoint);
				_actor.Cleave(lineDirection);
			}
		}

		private void OnTriggerStay(Collider other){
			if(other.gameObject.layer == LayerMask.NameToLayer("Enemy")){
				_contactTime += Time.fixedDeltaTime;
				if(_contactTime > 2f){
					EventBus.Post(new ActorDied());
					_contactTime = 0;
				}
			}
		}

		private void OnTriggerExit(Collider other){
			_contactTime = 0;
		}
	}

	public class ActorDied{ }
}