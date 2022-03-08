using Actor.Scripts;
using UnityEngine;
using UnityEngine.Assertions;

namespace Actor.ActorTests{
	public class GestureTest{
		[NUnit.Framework.Test]
		public void LineCalculate_Up(){
			var startPoint = Vector3.zero;
			var endPoint = Vector3.up;
			var gestureCalculator = new GestureCalculator();
			var lineDirection = gestureCalculator.CalculateLineDirection(startPoint, endPoint);
			var expectDirection = Vector3.up;
			Assert.AreEqual(expectDirection, lineDirection);
		}

		[NUnit.Framework.Test]
		public void LineCalculate_Right(){
			var startPoint = Vector3.zero;
			var endPoint = Vector3.right;
			var gestureCalculator = new GestureCalculator();
			var lineDirection = gestureCalculator.CalculateLineDirection(startPoint, endPoint);
			var expectDirection = Vector3.right;
			Assert.AreEqual(expectDirection, lineDirection);
		}
	}
}