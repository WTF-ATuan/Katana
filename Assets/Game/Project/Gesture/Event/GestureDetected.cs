using UnityEngine;

namespace Project.Gesture.Event{
	public class GestureDetected{
		public string GestureName{ get; }
		public Vector3[] Points{ get; }
		public Vector3 Center{ get; }

		public GestureDetected(string gestureName, Vector3[] points, Vector3 center){
			GestureName = gestureName;
			Points = points;
			Center = center;
		}
	}
}