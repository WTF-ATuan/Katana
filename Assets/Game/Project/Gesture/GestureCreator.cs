using System;
using System.Collections.Generic;
using PDollarGestureRecognizer;
using UnityEngine;

namespace Project.Gesture{
	public class GestureCreator{

		private readonly List<Point> _pointList = new();

		public void AddPoint(IEnumerable<Vector2> points , int strokesIndex){
			foreach(var point in points){
				var pointValue = new Point(point.x, -point.y, strokesIndex);
				_pointList.Add(pointValue);
			}
		}

		public void AddGesture(string gestureName){
			var fileName = $"{Application.persistentDataPath}/{gestureName}-{DateTime.Now.ToFileTime()}.xml";
			GestureIO.WriteGesture(_pointList.ToArray(), gestureName, fileName);
		}
	}
}