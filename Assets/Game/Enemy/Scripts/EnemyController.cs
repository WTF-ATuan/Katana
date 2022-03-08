using UnityEngine;

namespace Enemy.Scripts{
	public class EnemyController : MonoBehaviour{
		private Enemy _enemy;
		private EnemyBehavior _enemyBehavior;
		private void Start(){
			_enemy = GetComponent<Enemy>();
			_enemyBehavior = new EnemyBehavior(_enemy);
		}

		private void Update(){
			_enemyBehavior.Condition();
		}
	}
}