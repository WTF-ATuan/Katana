using System;
using Actor.Scripts;
using NUnit.Framework;
using UnityEngine;

namespace Actor.ActorTests{
	public class ActorMoveTest{
		private Scripts.Actor actor;
		private GameObject testObject;

		[SetUp]
		public void Setup(){
			testObject = new GameObject();
			actor = testObject.AddComponent<Scripts.Actor>();
		}

		[Test]
		public void Actor_Not_Have_MoveBehavior(){
			Assert.Throws<Exception>(() => actor.Move());
		}

		[Test]
		public void Actor_Forward_Move(){
			var forward = testObject.AddComponent<ForwardMove>();
			actor.MoveBehavior = forward;
			var position1 = actor.Position;
			actor.Move();
			var position2 = actor.Position;
			Assert.AreNotEqual(position1, position2);
		}
	}
}