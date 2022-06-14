using System;
using System.Collections;
using UnityEngine;

namespace Map.Scripts{
	public class AnimationTimeControl : MonoBehaviour{
		[SerializeField] private float duringLimit = 10;

		private Animator _animator;

		private float _timer;

		private void Start(){
			_animator = GetComponent<Animator>();
			StartCoroutine(AddedAnimatorTime());
		}

		private IEnumerator AddedAnimatorTime(){
			while(gameObject.activeSelf){
				if(_animator.speed > duringLimit){
					break;
				}

				_animator.speed += 0.1f;
				yield return new WaitForSeconds(1f);
			}
		}
	}
}