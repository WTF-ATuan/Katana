using System.Collections.Generic;
using UnityEngine;

namespace Katana.Scripts{
	public class KatanaInput : MonoBehaviour{
		private Katana _katana;
		private void Start(){
			_katana = GetComponent<Katana>();
		}
	}
}