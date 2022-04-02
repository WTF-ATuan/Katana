using UnityEngine;

namespace Actor.Scripts{
	public class Actor : MonoBehaviour{
		public Vector3 Position => transform.position;
		
		
		
		
		//TODO when Katana Animation is Done we use EventBus to Handle 
		public void Cleave(Katana.Scripts.Katana katana, Vector3 cleaveDirection){
			katana.PlayAnimation(cleaveDirection);
		}
	}
}