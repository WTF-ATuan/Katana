using UnityEngine;

namespace Game.Enemy.Scripts.Slice.Event{
	public class ActorSliced{
		public Plane Plane{ get; }
		public GameObject CurrentObject{ get; }
		public GameObject NegObject{ get; }
		public GameObject PosObject{ get; }

		public ActorSliced(Plane plane, GameObject currentObject, GameObject negObject, GameObject posObject){
			Plane = plane;
			CurrentObject = currentObject;
			NegObject = negObject;
			PosObject = posObject;
		}
	}
}