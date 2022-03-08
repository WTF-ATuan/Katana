using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy.Scripts{
	public class EnemySpawner : MonoBehaviour{
		[SerializeField] private Enemy preEnemy;
		[SerializeField] private Transform targetCenter;
		[SerializeField] private float spawnDuring;

		private ColdDownTimer _timer;
		private List<Enemy> _enemyList;

		private void Start(){
			_timer = new ColdDownTimer(spawnDuring);
			_enemyList = new List<Enemy>();
		}

		private void Update(){
			var canInvoke = _timer.CanInvoke();
			if(!canInvoke) return;
			SpawnEnemy();
			_timer.Reset();
		}

		private void SpawnEnemy(){
			var targetPosition = targetCenter.position;
			var randomSpawnPosition = GetRandomSpawnPosition(targetPosition);
			var enemy = CreateEnemy(randomSpawnPosition);
			InitEnemy(enemy, targetPosition);
		}

		public void InitEnemy(Enemy enemy, Vector3 targetPosition){
			enemy.SetTargetPosition(targetPosition);
			_enemyList.Add(enemy);
		}

		public Enemy CreateEnemy(Vector3 spawnPosition){
			var enemy = Instantiate(preEnemy, spawnPosition, Quaternion.identity);
			return enemy;
		}

		private Vector3 GetRandomSpawnPosition(Vector3 center){
			var rangeValue = Random.Range(1, 5);
			var spawnPosition = rangeValue switch{
				1 => center + new Vector3(1, 0, 0) * 20,
				2 => center + new Vector3(-1, 0, 0) * 20,
				3 => center + new Vector3(0, 0, 1) * 20,
				4 => center + new Vector3(0, 0, -1) * 20,
				_ => throw new ArgumentOutOfRangeException()
			};

			return center + new Vector3(0, 0, 1) * 20;
		}
	}
}