using Actor.Scripts;
using Game.Enemy.Scripts.Slice.Event;
using Project;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Battle.Scripts{
	public class EnemyPresenter : MonoBehaviour{
		[SerializeField] private UnityEvent onActorDied;

		[SerializeField] private TextMeshProUGUI enemyKilledText;
		private int _slicedCount = 0;

		public void Refresh(){
			EventBus.Subscribe<ActorSliced>(OnActorSliced);
			EventBus.Subscribe<ActorDied>(x => onActorDied.Invoke());
			_slicedCount = 0;
			enemyKilledText.text = $"{_slicedCount}";
		}

		private void OnActorSliced(ActorSliced obj){
			_slicedCount++;
			enemyKilledText.text = $"{_slicedCount}";
		}
	}
}