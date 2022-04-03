using System.Linq;
using Project;
using Project.Gesture.Event;
using UnityEngine;

namespace Actor.Scripts{
	public class ActorController : MonoBehaviour{
		[SerializeField] private Katana.Scripts.Katana katana;

		private Actor _actor;
		private IMove moveBehavior;

		//TODO Gesture should be Project folder with other gesture scripts
		private readonly GestureCalculator _gestureCalculator = new();

		private void Start(){
			InitActor();
			EventHandle();
		}

		private void InitActor(){
			_actor = GetComponent<Actor>();
			moveBehavior = GetComponent<IMove>();
			_actor.MoveBehavior = moveBehavior;
		}

		private void EventHandle(){
			EventBus.Subscribe<GestureDetected>(OnGestureDetected);
		}

		private void Update(){
			if(moveBehavior != null){
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
				_actor.Cleave(katana, lineDirection);
			}
		}
	}
}