using UnityEngine;

namespace Katana.Scripts{
	public class Katana : MonoBehaviour{
		[SerializeField] private Transform bladePoint;
		public Vector3 BladePosition => bladePoint.position;
		public Vector3 BladePlaneNormal => -bladePoint.right;


		private Animator _animator;

		private void Start(){
			_animator = GetComponentInChildren<Animator>();
		}

		public void PlayAnimation(Vector3 direction){
			if(direction == Vector3.left){
				_animator.Play($"Cleave_Left");
			}

			if(direction == Vector3.right){
				_animator.Play($"Cleave_Right");
			}
		}
	}
}