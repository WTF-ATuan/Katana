using System;
using BzKovSoft.ObjectSlicer.EventHandlers;
using UnityEngine;

namespace Game.Enemy.Scripts.Application{
	public class PieceDestroyer : MonoBehaviour, IBzObjectSlicedEvent{
		public void ObjectSliced(GameObject original, GameObject resultNeg, GameObject resultPos){
			Destroy(transform.parent.gameObject, 2f);
			Destroy(resultNeg, 2f);
			Destroy(resultPos, 2f);
		}
	}
}