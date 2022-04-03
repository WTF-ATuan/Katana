using Sirenix.OdinInspector;
using UnityEngine;

namespace Map.Scripts{
	public class SquarePoint : MonoBehaviour{
		[ProgressBar(1, 10, 0, 0, 0)] public int width = 5;
		[ProgressBar(1, 10, 1, 1, 1)] public int length = 5;

		public Vector3 Position => transform.position;
		public Vector3 RightDirection => transform.right;
		public Vector3 ForwardDirection => transform.forward;

		public bool IsInPoint(Vector3 position){
			var pointPosition = transform.position;
			var absPosition = new Vector3(Mathf.Abs(position.x), 0, Mathf.Abs(position.y));
			var size = new Vector3(pointPosition.x + length, 0, pointPosition.z + width);
			var lenght = absPosition - size;
			return !(lenght.x > 0) && !(lenght.z > 0);
		}

		private void OnDrawGizmos(){
			Gizmos.color = Color.blue;
			Gizmos.DrawWireCube(transform.position, new Vector3(length, 0.1f, width));
		}
	}
}