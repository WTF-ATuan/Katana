using UnityEngine;

namespace Katana.Scripts{
	public class Slicer{
		public void Slice(GameObject obj, Vector3 startPoint, Vector3 endPoint){ }

		private bool ConvertPlane(GameObject obj, ref DividePlane plane){
			var meshFilter = obj.GetComponent<MeshFilter>();
			if(!meshFilter) return false;
			var worldToLocalMatrix = obj.transform.worldToLocalMatrix;
			var multiplyPoint1 = worldToLocalMatrix.MultiplyPoint(plane.Vertex1);
			var multiplyPoint2 = worldToLocalMatrix.MultiplyPoint(plane.Vertex2);
			var multiplyPoint3 = worldToLocalMatrix.MultiplyPoint(plane.Vertex3);
			plane.Point = multiplyPoint2;
			plane.Normal = Vector3.Cross(multiplyPoint3 - multiplyPoint2, multiplyPoint1 - multiplyPoint2).normalized;
			return true;
		}

		private bool IsIntersect(DividePlane plane, DivideSegment segment){
			if(!segment.Available) return false;
			var distance1 = segment.StartPoint - plane.Point;
			var distance2 = segment.EndPoint - plane.Point;
			var dot1 = Vector3.Dot(distance1, plane.Normal);
			var dot2 = Vector3.Dot(distance2, plane.Normal);
			return dot1 * dot2 < 0;
		}
		
	}

	public struct DividePlane{
		public Vector3 Normal;
		public Vector3 Point;
		public Vector3 Vertex1, Vertex2, Vertex3;
	}

	public struct DivideSegment{
		public Vector3 StartPoint, EndPoint;
		public bool Available => StartPoint != EndPoint;

		public DivideSegment(Vector3 startPoint, Vector3 endPoint){
			StartPoint = startPoint;
			EndPoint = endPoint;
		}
	}
}