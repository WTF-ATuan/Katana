using UnityEngine;

namespace Map.Scripts{
	public static class ExtendingVector3{
		public static bool IsGreaterOrEqual(this Vector3 local, Vector3 other){
			return local.x >= other.x && local.y >= other.y && local.z >= other.z;
		}

		public static bool IsLesserOrEqual(this Vector3 local, Vector3 other){
			return local.x <= other.x && local.y <= other.y && local.z <= other.z;
		}

		public static Vector3 DirectionalPosition(this Vector3 local, Vector3 other){
			var localX = local.x;
			var localZ = local.z;
			var otherX = other.x;
			var otherZ = other.z;
			var directionalPosition = new Vector3(localX * otherX, 0, localZ * otherZ);
			return directionalPosition;
		}
	}
}