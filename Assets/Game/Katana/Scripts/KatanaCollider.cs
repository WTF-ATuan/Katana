using System;
using UnityEngine;

namespace Katana.Scripts{
	public class KatanaCollider : MonoBehaviour{
		private Katana _katana;

		private void Start(){
			_katana = GetComponentInParent<Katana>();
		}

		private void OnCollisionEnter(Collision other){
			_katana.CleaveEnter(other);
		}

		private void OnCollisionExit(Collision other){
			_katana.CleaveExit(other);
		}
	}
}