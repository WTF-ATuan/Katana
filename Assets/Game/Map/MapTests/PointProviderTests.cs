using Map.Scripts;
using NUnit.Framework;
using UnityEngine;

namespace Game.Map.MapTests{
	[TestFixture]
	public class PointProviderTests{
		private PointProvider provider;

		[SetUp]
		public void Setup(){
			provider = new PointProvider();
			SetUpPoint();
		}

		private void SetUpPoint(){
			var center = new GameObject().AddComponent<SquarePoint>();
			var left = new GameObject{
				transform ={
					position = Vector3.left
				}
			}.AddComponent<SquarePoint>();
			var right = new GameObject{
				transform ={
					position = Vector3.right
				}
			}.AddComponent<SquarePoint>();
			provider.Add(center);
			provider.Add(left);
			provider.Add(right);
		}

		[Test]
		public void Get_Enemy_Spawn_Point(){ }
	}
}