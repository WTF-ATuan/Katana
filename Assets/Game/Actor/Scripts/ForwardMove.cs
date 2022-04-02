using Sirenix.OdinInspector;
using UnityEngine;

namespace Actor.Scripts{
	public class ForwardMove : MonoBehaviour, IMove{
		[BoxGroup("Basic")] [SerializeField] [ProgressBar(0.5f, 5.0f)]
		private float actorMoveSpeed = 2f;

		public bool CanMove(){
			return true;
		}

		public void Move(){
			var forwardDirection = transform.forward;
			transform.position += forwardDirection * actorMoveSpeed;
		}
	}
}