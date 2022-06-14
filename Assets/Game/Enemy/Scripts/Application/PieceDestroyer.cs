using System;
using BzKovSoft.ObjectSlicer.EventHandlers;
using UnityEngine;

namespace Game.Enemy.Scripts.Application{
	public class PieceDestroyer : MonoBehaviour, IBzObjectSlicedEvent{
		public void ObjectSliced(GameObject original, GameObject resultNeg, GameObject resultPos){
			Destroy(transform.parent.gameObject, 1.2f);
			Destroy(resultNeg, 1.2f);
			Destroy(resultPos, 1.2f);
		}
	}
}