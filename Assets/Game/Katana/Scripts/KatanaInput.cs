using System.Collections.Generic;
using UnityEngine;

namespace Katana.Scripts{
	public class KatanaInput : MonoBehaviour{
		private Katana _katana;
		private void Start(){
			_katana = GetComponent<Katana>();
		}
		
		private Vector2 GetMousePosition(){
			if(Camera.main is null) return Vector2.zero;
			var mousePosition = Input.mousePosition;
			mousePosition.z = Camera.main.nearClipPlane;
			var worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
			worldPoint.z = 0;
			return worldPoint;
		}
	}
}