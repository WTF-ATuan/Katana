using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Katana.Scripts{
	public class KatanaCollider : MonoBehaviour{
		private Katana _katana;

		private void Start(){
			_katana = GetComponentInParent<Katana>();
		}

		private void OnCollisionEnter(Collision other){
			var enemy = other.gameObject.GetComponent<Enemy.Scripts.Enemy>();
			if(enemy){
				var contactPoints = other.contacts;
				DamageEnemy(enemy, contactPoints);
			}
		}

		private void DamageEnemy(Enemy.Scripts.Enemy enemy, ContactPoint[] contactPoints){
			var damagePoints = contactPoints.Select(x => x.point).ToList();
			enemy.TakeDamage(damagePoints);
		}
	}
}