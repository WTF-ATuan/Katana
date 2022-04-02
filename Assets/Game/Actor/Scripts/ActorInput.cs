using System.Linq;
using Katana.Scripts;
using Project;
using Project.Gesture.Event;
using UnityEngine;

namespace Actor.Scripts{
	public class ActorInput : MonoBehaviour{
		private Actor _actor;
		[SerializeField] private Katana.Scripts.Katana katana;
		private readonly GestureCalculator _gestureCalculator = new();

		private void Start(){
			_actor = GetComponent<Actor>();
			EventBus.Subscribe<GestureDetected>(OnGestureDetected);
		}

		private void OnGestureDetected(GestureDetected obj){
			var gestureName = obj.GestureName;
			var points = obj.Points;
			var center = obj.Center;
			if(gestureName.Equals("line")){
				var firstPoint = points.First();
				var lastPoint = points.Last();
				var lineDirection = _gestureCalculator.CalculateLineDirection(firstPoint, lastPoint);
				_actor.Cleave(katana, lineDirection);
			}
		}
	}
}