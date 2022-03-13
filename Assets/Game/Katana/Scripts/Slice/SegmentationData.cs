using UnityEngine;

namespace Katana.Scripts{
	public class SegmentationData{
		public Vector3 Normal{ get; }
		public Vector3 Position{ get; }
		public Plane Plane{ get; }

		public SegmentationData(Vector3 normal, Vector3 position){
			Normal = normal;
			Position = position;
			Plane = new Plane(Normal, Position);
		}

		public SegmentationData(Vector3 startSlicePoint, Vector3 endSlicePoint, Vector3 position){
			var cross = Vector3.Cross(startSlicePoint, endSlicePoint);
			Normal = cross;
			Position = position;
			Plane = new Plane(cross, position);
		}
	}
}