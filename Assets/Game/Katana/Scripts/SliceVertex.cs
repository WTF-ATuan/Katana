using UnityEngine;

namespace Katana.Scripts{
	public class SliceVertex{
		public Vector3 CollisionPosition;
		private readonly Vector3 pointToDirection;
		private readonly Vector3 movingDirection;

		public Vector3 CrossDirection => Vector3.Cross(pointToDirection, movingDirection);

		public SliceVertex(Vector3 collisionPosition, Vector3 pointToDirection, Vector3 movingDirection){
			CollisionPosition = collisionPosition;
			this.pointToDirection = pointToDirection;
			this.movingDirection = movingDirection;
		}
	}
}