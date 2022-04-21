using UnityEngine;

namespace Actor.Scripts{
	public class GestureCalculator{
		public Vector3 CalculateLineDirection(Vector3 startPoint, Vector3 lastPoint){
			var lineDirection = lastPoint - startPoint;
			var angle = Mathf.Atan2(lineDirection.x, lineDirection.y) * Mathf.Rad2Deg;
			var finalAngle = angle > 0 ? angle : 180 + (180 + angle);
			return finalAngle switch{
				>= 330 or <= 30 => Vector3.down,
				>= 40 and <= 140 => Vector3.right,
				>= 150 and <= 210 => Vector3.up,
				>= 220 and <= 320 => Vector3.left,
				_ => Vector3.zero
			};
		}
	}
}