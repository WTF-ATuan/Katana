using System.Collections.Generic;
using System.Linq;
using BzKovSoft.ObjectSlicer.Samples;
using UnityEngine;

namespace Katana.Scripts{
	public class KatanaCollider : MonoBehaviour{
		private Katana _katana;

		private void Start(){
			_katana = GetComponentInParent<Katana>();
		}

		private void OnCollisionEnter(Collision other){
			var enemy = other.gameObject.GetComponent<Enemy.Scripts.Enemy>();
			var sliceable = other.gameObject.GetComponentInParent<IBzSliceableNoRepeat>();
			var contactPoints = other.contacts;
			if(sliceable != null){
				SliceEnemy(sliceable, contactPoints);
			}

			if(enemy){
				DamageEnemy(enemy, contactPoints);
			}
		}

		private void DamageEnemy(Enemy.Scripts.Enemy enemy, IEnumerable<ContactPoint> contactPoints){
			var damagePoints = contactPoints.Select(x => x.point).ToList();
			enemy.TakeDamage(damagePoints);
		}

		private int sliceCount;

		private void SliceEnemy(IBzSliceableNoRepeat sliceableObject, IEnumerable<ContactPoint> contactPoints){
			var point = contactPoints.First().point;
			var normal = Vector3.Cross(_katana.MoveDirection, _katana.BladeDirection);
			var plane = new Plane(normal, point);
			sliceableObject.Slice(plane, 0, null);
			sliceCount++;
		}
	}
}