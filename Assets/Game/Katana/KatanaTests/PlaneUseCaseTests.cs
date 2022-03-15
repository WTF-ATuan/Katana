using NUnit.Framework;
using UnityEngine;

namespace Game.Katana.KatanaTests{
	public class PlaneUseCaseTests{
		[Test]
		public void Vector3CrossMethod(){
			//左手規則。
			var point1 = Vector3.right; //thumb
			var point2 = Vector3.up; //index finger
			var expectPoint = Vector3.forward; //middle finger
			var crossPoint = Vector3.Cross(point1, point2);
			Assert.AreEqual(expectPoint, crossPoint);
		}

		[Test]
		public void Create_Plane_With_MoveDirection(){
			var moveDirection = Vector3.forward;
			var pointDirection = Vector3.up;
			var crossPoint = Vector3.Cross(moveDirection, pointDirection);
			var expectPoint = Vector3.left;
			Assert.AreEqual(crossPoint, expectPoint);
			var plane = new Plane(crossPoint, Vector3.zero);
			var isPositiveSide = plane.GetSide(expectPoint);
			Assert.IsTrue(isPositiveSide);
		}

		[Test]
		public void Create_Plane(){
			var plane = new Plane(Vector3.up, Vector3.zero);
			var positiveSide = Vector3.up * 50f;
			var negativeSide = Vector3.down * 50f;
			var side1 = plane.GetSide(positiveSide);
			var side2 = plane.GetSide(negativeSide);
			Assert.IsTrue(side1);
			Assert.IsFalse(side2);
		}
	}
}