using NUnit.Framework;
using UnityEngine;

namespace Game.Katana.KatanaTests{
	public class SliceTests{
		[Test]
		public void Vector3CrossMethod(){
			//左手規則。
			var point1 = Vector3.right;
			var point2 = Vector3.up;
			var expectPoint = Vector3.forward;
			var crossPoint = Vector3.Cross(point1 , point2);
			Assert.AreEqual(expectPoint , crossPoint);
		}

	}
}