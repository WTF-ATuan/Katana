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
			var sidePoint = GetSidePoint(centerPoint);
			var rightPoints = GetSameSidePoints(centerPoint, sidePoint, true);
			var leftPoints = GetSameSidePoints(centerPoint, sidePoint, false);
			sidePositions[0] = leftPoints.First().Position;
			sidePositions[1] = rightPoints.First().Position;

			return sidePositions;
		}

		private List<SquarePoint> GetSidePoint(SquarePoint centerPoint){
			var forwardDirection = centerPoint.Position.DirectionalPosition(centerPoint.ForwardDirection);
			var sidePoint = (from point in pointList
				let pointDirection = point.Position.DirectionalPosition(point.ForwardDirection)
				where forwardDirection.Equals(pointDirection)
				select point).ToList();
			sidePoint.Remove(centerPoint);
			return sidePoint;
		}

		private List<SquarePoint> GetSameSidePoints(SquarePoint centerPoint, List<SquarePoint> sameSidePoints,
			bool isRight){
			var rightDirection = centerPoint.Position.DirectionalPosition(centerPoint.RightDirection);
			var rightPoints = new List<SquarePoint>();
			var leftPoints = new List<SquarePoint>();
			foreach(var point in sameSidePoints){
				var pointDirection = point.Position.DirectionalPosition(point.RightDirection);
				if(pointDirection.IsGreaterOrEqual(rightDirection)){
					rightPoints.Add(point);
				}
				else{
					leftPoints.Add(point);
				}
			}

			return isRight ? rightPoints : leftPoints;
		}
	}
}