using UnityEngine;

namespace Enemy.Scripts{
	[CreateAssetMenu(fileName = "EnemyData", menuName = "Project/EnemyData")]
	public class EnemyData : ScriptableObject{
		public float moveSpeed;
		public float maxAttackDistance;
	}
}