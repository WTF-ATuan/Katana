using Map.Scripts;
using NUnit.Framework;
using UnityEngine;

namespace Game.Map.MapTests{
	[TestFixture]
	public class PointProviderTests{
		private PointProvider provider;

		private SquarePoint center, left, right;

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
			provider.Add(center);
			provider.Add(left);
			provider.Add(right);
		}

		[Test]
		public void Get_Enemy_Spawn_Point(){
			var spawnPosition = provider.GetSpawnPosition(center.Position);
			var expectSpawnPosition = left.Position;
			Assert.AreEqual(expectSpawnPosition, spawnPosition);
		}

		[Test]
		public void Get_Side_Position(){
			var sidePosition = provider.GetSidePosition(center.Position);
			var leftPoint = sidePosition[0];
			var rightPoint = sidePosition[1];
			Assert.AreEqual(left.Position, leftPoint);
			Assert.AreEqual(right.Position, rightPoint);
		}
	}
}