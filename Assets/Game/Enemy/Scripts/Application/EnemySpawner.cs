using System.Collections.Generic;
using System.Linq;
using Game.Enemy.Scripts.UseCase;
using Game.Project;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Enemy.Scripts.Application{
	public class EnemySpawner : MonoBehaviour{
		[SerializeField] private Transform target;
		[SerializeField] private List<GameObject> enemyTypes;
		[SerializeField] private List<Transform> spawnPoints;

		private ColdDownTimer _timer;

		private void Start(){
			_timer = new ColdDownTimer(3f);
		}

		private void Update(){
			var canInvoke = _timer.CanInvoke();
			if(!canInvoke) return;
			RandomSpawn();
			var randomNumber = Random.Range(2, 5);
			_timer.ModifyDuring(randomNumber);
			_timer.Reset();
		}

		public void RandomSpawn(){
			var randomEnemyNumber = Random.Range(0, enemyTypes.Count);
			var enemyPrefab = enemyTypes[randomEnemyNumber];
			var randomSpawnNumber = Random.Range(0, spawnPoints.Count);
			var randomPosition =
					spawnPoints[randomSpawnNumber].position + Vector3.up * enemyPrefab.transform.position.y;
			var enemy = Instantiate(enemyPrefab, randomPosition, enemyPrefab.transform.rotation);
			InitEnemy(enemy);
		}

		public void InitEnemy(GameObject obj){
			var moveBehavior = obj.GetComponent<AutoMoveBehavior>();
			moveBehavior.target = target;
			var randomNumber = Random.Range(3, 7);
			moveBehavior.moveSpeed = randomNumber;
			moveBehavior.Init();
		}
	}
}