using UnityEngine;

namespace Katana.Scripts{
	public class Katana : MonoBehaviour{
		[SerializeField] private Transform bladePoint;
		public Vector3 bladePosition => bladePoint.position;
		public Vector3 bladeNormal => -bladePoint.right;
		
	}
}