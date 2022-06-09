using System.Collections.Generic;
using Project.Gesture.Event;
using UnityEngine;

#pragma warning disable 618

namespace Project.Gesture{
	[RequireComponent(typeof(LineRenderer))]
	public class GestureDrawer : MonoBehaviour{
		private GestureRecognizer _recognizer;
		private List<Vector3> _pointList;
		private LineRenderer _lineRenderer;
		private Camera _userCamera;

		private void Start(){
			_lineRenderer = GetComponent<LineRenderer>();
			_pointList = new List<Vector3>();
			_recognizer = new GestureRecognizer();
			_userCamera = !Camera.main ? FindObjectOfType<Camera>() : Camera.main;
		}

		private void Update(){
			var runtimePlatform = Application.platform;
			if(runtimePlatform is RuntimePlatform.Android or RuntimePlatform.IPhonePlayer){
				MobileDetector();
			}
			else{
				ComputerDetector();
			}
		}

		private void ComputerDetector(){
			var inputPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
			if(Input.GetMouseButtonDown(0)){
				ResetLinePoint();
			}

			if(Input.GetMouseButton(0)){
				DrawLinePoint(inputPosition.x, inputPosition.y);
			}

			if(Input.GetMouseButtonUp(0)){
				RecognizeLinePoint();
			}
		}

		private void MobileDetector(){
			var touch = Input.GetTouch(0);
			var inputPosition = new Vector3(touch.position.x, touch.position.y);
			var touchPhase = touch.phase;

			if(touchPhase == TouchPhase.Began){
				ResetLinePoint();
			}

			if(touchPhase == TouchPhase.Moved){
				DrawLinePoint(inputPosition.x, inputPosition.y);
			}

			if(touchPhase == TouchPhase.Ended){
				RecognizeLinePoint();
			}
		}

		private void ResetLinePoint(){
			_pointList.Clear();
			_lineRenderer.SetVertexCount(0);
		}

		private void DrawLinePoint(float pointX, float pointY){
			_pointList.Add(new Vector3(pointX, -pointY));
			var listCount = _pointList.Count;
			_lineRenderer.SetVertexCount(listCount);
			var worldPoint = _userCamera.ScreenToWorldPoint(new Vector3(pointX, pointY, 10));
			_lineRenderer.SetPosition(listCount - 1, worldPoint);
		}

		private void RecognizeLinePoint(){
			var centerOfPoint = _lineRenderer.bounds.center;
			_recognizer.AddPoint(_pointList.ToArray(), 0);
			var result = _recognizer.Recognize();
			EventBus.Post(new GestureDetected(result, _pointList.ToArray(), centerOfPoint));
		}
	}
}