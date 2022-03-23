using System;
using PlasticPipe.PlasticProtocol.Client;
using UnityEngine;

namespace Enemy.Scripts{
	public class Enemy : MonoBehaviour{
		public Transform TargetTransform{ get; private set; }
		
		public void Initialize(Transform targetPoint){
			TargetTransform = targetPoint;
		}
		
	}
}