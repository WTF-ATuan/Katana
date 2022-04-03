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

		public Vector3 GetSpawnPosition(Vector3 centerPosition){
			var centerPoint = pointList.Find(x => x.IsInPoint(centerPosition));
			return default;
		}
	}
}