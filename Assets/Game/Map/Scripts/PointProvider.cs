using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Map.Scripts{
	//<Feature>
	//Get enemy Spawn Point 
	//Get enemy move target point 
	public class PointProvider{
		private readonly List<SquarePoint> pointList = new();

		public void Add(SquarePoint point){
			pointList.Add(point);
		}

		public void Remove(SquarePoint point){
			var contains = pointList.Contains(point);
			if(!contains) return;
			pointList.Remove(point);
		}

		public Vector3[] GetSidePosition(Vector3 centerPosition){
			var sidePositions = new Vector3[2];
			var centerPoint = pointList.Find(x => x.IsInPoint(centerPosition));
			var forwardDirection = CalculateDirection(centerPoint.Position, centerPoint.ForwardDirection);
			//find Side Point Pass
			var sidePoint = (from point in pointList
				let pointDirection = CalculateDirection(point.Position, point.ForwardDirection)
				where forwardDirection.Equals(pointDirection)
				select point).ToList();
			sidePoint.Remove(centerPoint);
			//find Side Point Pass
			var rightDirection = CalculateDirection(centerPoint.Position, centerPoint.RightDirection);
			var rightPoints = new List<SquarePoint>();
			var leftPoints = new List<SquarePoint>();
			foreach(var point in sidePoint){
				var pointDirection = CalculateDirection(point.Position, point.RightDirection);
				if(pointDirection.IsGreaterOrEqual(rightDirection)){
					rightPoints.Add(point);
				}
				else{
					leftPoints.Add(point);
				}
			}

			sidePositions[0] = leftPoints.First().Position;
			sidePositions[1] = rightPoints.First().Position;

			return sidePositions;
		}

		private Vector3 CalculateDirection(Vector3 position, Vector3 direction){
			var positionX = position.x;
			var positionZ = position.z;
			var directionX = direction.x;
			var directionZ = direction.z;
			var finalPosition = new Vector3(positionX * directionX, 0, positionZ * directionZ);
			return finalPosition;
		}
	}
}