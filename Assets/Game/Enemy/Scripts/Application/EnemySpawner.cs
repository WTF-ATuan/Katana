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

		private ColdDownTimer timer;

		private void Start(){
			timer = new ColdDownTimer(3f);
		}

		private void Update(){
			var canInvoke = timer.CanInvoke();
			if(!canInvoke) return;
			RandomSpawn();
			var randomNumber = Random.Range(2, 5);
			timer.ModifyDuring(randomNumber);
			timer.Reset();
		}

		public void RandomSpawn(){
			var enemyPrefab = enemyTypes.First();
			var randomNumber = Random.Range(0, spawnPoints.Count);
			var randomPosition = spawnPoints[randomNumber].position;
			var enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
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