using Map.Scripts;
using NUnit.Framework;
using UnityEngine;

namespace Game.Map.MapTests{
	public class PointTests{
		private SquarePoint point;

		[SetUp]
		public void Setup(){
			var testObject = new GameObject{
				transform ={
					position = Vector3.one
				}
			};
			point = testObject.AddComponent<SquarePoint>();
			point.length = 5;
			point.width = 5;
		}

		[Test]
		public void IsInPoint(){
			var position = new Vector3(2, 2, 2);
			var isInPoint = point.IsInPoint(position);
			Assert.IsTrue(isInPoint);
		}

		[Test]
		public void IsNotInPoint(){
			var position = new Vector3(10, 10, 10);
			var isInPoint = point.IsInPoint(position);
			Assert.IsFalse(isInPoint);
		}
	}
}