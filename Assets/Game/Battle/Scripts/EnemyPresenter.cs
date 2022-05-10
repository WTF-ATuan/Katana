using Game.Enemy.Scripts.Slice.Event;
using Project;
using TMPro;
using UnityEngine;

namespace Game.Battle.Scripts{
	public class EnemyPresenter : MonoBehaviour{
		[SerializeField] private TextMeshProUGUI enemyKilledText;
		private int _slicedCount = 0;

		private void Start(){
			EventBus.Subscribe<ActorSliced>(OnActorSliced);
			enemyKilledText.text = $"Enemy Killed : {_slicedCount}";
		}

		private void OnActorSliced(ActorSliced obj){
			_slicedCount++;
			enemyKilledText.text = $"Enemy Killed : {_slicedCount}";
		}
	}
}