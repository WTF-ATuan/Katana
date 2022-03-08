namespace Enemy.Scripts{
	public class EnemyBehavior{
		public Enemy Enemy{ get; }

		public EnemyBehavior(Enemy enemy){
			Enemy = enemy;
		}

		public void Condition(){
			var distanceOfTarget = Enemy.DistanceOfTarget(Enemy.TargetPosition);
			if(distanceOfTarget > 1){
				Enemy.Move();
				Enemy.SetFaceDirection();
			}
		}
	}
}