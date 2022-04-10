using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Map.Scripts{
	public class MapController : MonoBehaviour{
		[ReadOnly] [ShowInInspector] private List<SquarePoint> points;
		private PointProvider pointProvider;

		private void Start(){
			points = GetComponentsInChildren<SquarePoint>().ToList();
			pointProvider = new PointProvider(points);
		}
	}
}