using Sirenix.OdinInspector;
using UnityEngine;

namespace Map.Scripts{
	public class SquarePoint : MonoBehaviour{
		[ProgressBar(1, 5)] public int width;
		[ProgressBar(1, 5)] public int length;

		public bool IsInPoint(Vector3 position){
			var pointPosition = transform.position;
			var absPosition = new Vector3(Mathf.Abs(position.x), 0, Mathf.Abs(position.y));
			var size = new Vector3(pointPosition.x + length, 0, pointPosition.z + width);
			var lenght = absPosition - size;
			return !(lenght.x > 0) && !(lenght.z > 0);
		}

		private void OnDrawGizmos(){
			Gizmos.color = Color.green;
			Gizmos.DrawWireCube(transform.position, new Vector3(length, 0.1f, width));
		}
	}
}