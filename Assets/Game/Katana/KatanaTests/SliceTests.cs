using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Game.Katana.KatanaTests{
	public class SliceTests{
		[Test]
		public void Vector3CrossMethod(){
			var point1 = Vector3.right;
			var point2 = Vector3.forward;
			var expectPoint = Vector3.up;
			var crossPoint = Vector3.Cross(point1 , point2);
			Assert.AreEqual(expectPoint , crossPoint);
		}
	}
}