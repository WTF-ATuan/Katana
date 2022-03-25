using System.Threading.Tasks;
using Game.Enemy.Scripts.Slice.Event;
using Project;
using UnityEngine;

namespace Game.Enemy.Scripts.Application{
	public class EnemyAutoSpawn : MonoBehaviour{
		[SerializeField] private GameObject prefabObject;

		[SerializeField] private Vector3 spawnPosition;

		private GameObject currentEnemy;

		private void Start(){
			EventBus.Subscribe<ActorSliced>(OnActorSliced);
		}

		private async void OnActorSliced(ActorSliced obj){
			var currentObject = obj.CurrentObject;
			if(currentEnemy == currentObject) return;
			await Task.Delay(2000);
			if(!UnityEngine.Application.isPlaying){
				return;
			}

			var negObject = obj.NegObject;
			var objPosObject = obj.PosObject;
			Destroy(negObject);
			Destroy(objPosObject);
			await Task.Delay(500);
			currentEnemy = Instantiate(prefabObject, spawnPosition, Quaternion.Euler(0, 180, 0));
		}
	}
}