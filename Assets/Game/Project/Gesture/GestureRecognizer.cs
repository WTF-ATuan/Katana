using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PDollarGestureRecognizer;
using UnityEngine;

namespace Project.Gesture{
	public class GestureRecognizer{
		//給他 vector 的點 返回手勢名稱 ex : input (0,0.1) ~ (0,1) output "Line"  
		private readonly List<PDollarGestureRecognizer.Gesture> _gesturesList = new();
		private readonly List<Point> _pointList = new();

		public GestureRecognizer(string dataPath){
			//Custom Gesture Input
			var filePaths = Directory.GetFiles(dataPath, "*.xml");
			foreach(var filePath in filePaths)
				_gesturesList.Add(GestureIO.ReadGestureFromFile(filePath));
			if(_gesturesList.Count >= 1) return;
			throw new Exception($"Not Custom Gesture In Data Folder {dataPath}");
		}

		public GestureRecognizer(){
			var gesturesXml = Resources.LoadAll<TextAsset>("CustomData/");
			var name = gesturesXml[0].name;
			foreach(var xmlAsset in gesturesXml)
				_gesturesList.Add(GestureIO.ReadGestureFromXML(xmlAsset.text));
			if(_gesturesList.Count >= 1) return;
			throw new Exception($"Not Custom Gesture In Resources Folder");
		}

		public void AddPoint(Vector3[] pointArray, int strokesIndex){
			foreach(var point in pointArray){
				var pointValue = new Point(point.x, -point.y, strokesIndex);
				_pointList.Add(pointValue);
			}
		}

		public string Recognize(){
			var isGraterMinimumDistance = IsGraterMinimumDistance(_pointList.ToArray());
			if(!isGraterMinimumDistance){
				_pointList.Clear();
				return "null";
			}

			var candidate = new PDollarGestureRecognizer.Gesture(_pointList.ToArray());
			var gestureResult = PointCloudRecognizer.Classify(candidate, _gesturesList.ToArray());
			_pointList.Clear();
			return gestureResult.GestureClass;
		}

		private bool IsGraterMinimumDistance(Point[] points){
			var firstPoint = new Vector2(points.First().X, points.First().Y);
			var lastPoint = new Vector2(points.Last().X, points.Last().Y);
			var distance = Vector2.Distance(firstPoint, lastPoint);
			return distance > 0.3f;
		}
	}
}