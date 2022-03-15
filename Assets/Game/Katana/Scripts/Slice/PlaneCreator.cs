using UnityEngine;

namespace Game.Katana.Scripts.Slice{
	public class PlaneCreator{
		public Plane CurrentSlicePlane{ get; private set; }

		
		public Vector3 DirectionOfPlane(Vector3 position){
			if(CurrentSlicePlane.Equals(default)) return Vector3.zero;
			var isPositiveSide = CurrentSlicePlane.GetSide(position);
			return isPositiveSide ? Vector3.up : Vector3.down;
		}
	}
}