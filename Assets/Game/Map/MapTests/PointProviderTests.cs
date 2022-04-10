using Map.Scripts;
using NUnit.Framework;
using UnityEngine;

namespace Game.Map.MapTests{
	[TestFixture]
	public class PointProviderTests{
		private PointProvider provider;

		private SquarePoint center, left, right, forward, forwardRight, forwardLeft, backRight;

		[SetUp]
		public void Setup(){
			provider = new PointProvider();
			SetUpPoint();
		}

		private void SetUpPoint(){
			center = new GameObject().AddComponent<SquarePoint>();
			left = new GameObject{
				transform ={
					position = Vector3.left
				}
			}.AddComponent<SquarePoint>();
			right = new GameObject{
				transform ={
					position = Vector3.right
				}
			}.AddComponent<SquarePoint>();
			forwardRight = new GameObject{
				transform ={
					position = new Vector3(1, 0, 1)
				}
			}.AddComponent<SquarePoint>();
			backRight = new GameObject{
				transform ={
					position = new Vector3(1, 0, -1)
				}
			}.AddComponent<SquarePoint>();
			forward = new GameObject{
				transform ={
					position = Vector3.forward
				}
			}.AddComponent<SquarePoint>();
			forwardLeft = new GameObject{
				transform ={
					position = new Vector3(-1, 0, 1)
				}
			}.AddComponent<SquarePoint>();
			provider.Add(center);
			provider.Add(left);
			provider.Add(right);
			provider.Add(forward);
			provider.Add(forwardLeft);
			provider.Add(forwardRight);
			provider.Add(backRight);
		}

		[Test]
		public void Get_Side_Position(){
			var sidePosition = provider.GetSidePosition(center.Position);
			var leftPoint = sidePosition[0];
			var rightPoint = sidePosition[1];
			Assert.AreEqual(left.Position, leftPoint);
			Assert.AreEqual(right.Position, rightPoint);
		}

		[Test]
		public void Get_UpSide_Position(){
			var upSidePosition = provider.GetIndexSidePosition(center.Position, 1);
			var upRightPoint = upSidePosition[1];
			Assert.AreEqual(forwardRight.Position, upRightPoint);
		}
	}
}