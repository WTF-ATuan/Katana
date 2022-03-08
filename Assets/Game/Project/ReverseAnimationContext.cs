using UnityEditor;
using UnityEngine;
using System.IO;

namespace Script.Tool{
	#if UNITY_EDITOR
	public static class ReverseAnimationContext{
		[MenuItem("Assets/Create Reversed Clip", false, 14)]
		private static void ReverseClip(){
			var directoryPath = System.IO.Path.GetDirectoryName(AssetDatabase.GetAssetPath(Selection.activeObject));
			var fileName = System.IO.Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject));
			var fileExtension = System.IO.Path.GetExtension(AssetDatabase.GetAssetPath(Selection.activeObject));
			fileName = fileName.Split('.')[0];
			var copiedFilePath =
					directoryPath + System.IO.Path.DirectorySeparatorChar + fileName + "_Reversed" + fileExtension;
			var clip = GetSelectedClip();

			AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(Selection.activeObject), copiedFilePath);

			clip = (AnimationClip) AssetDatabase.LoadAssetAtPath(copiedFilePath, typeof(AnimationClip));

			if(clip == null)
				return;
			var clipLength = clip.length;
			#pragma warning disable 618
			var curves = AnimationUtility.GetAllCurves(clip, true);
			#pragma warning restore 618
			clip.ClearCurves();
			foreach(var curve in curves){
				var keys = curve.curve.keys;
				var keyCount = keys.Length;
				var curvePostWrapMode = curve.curve.postWrapMode;
				curve.curve.postWrapMode = curve.curve.preWrapMode;
				curve.curve.preWrapMode = curvePostWrapMode;
				for(var i = 0; i < keyCount; i++){
					var K = keys[i];
					K.time = clipLength - K.time;
					var tmp = -K.inTangent;
					K.inTangent = -K.outTangent;
					K.outTangent = tmp;
					keys[i] = K;
				}

				curve.curve.keys = keys;
				clip.SetCurve(curve.path, curve.type, curve.propertyName, curve.curve);
			}

			var events = AnimationUtility.GetAnimationEvents(clip);
			if(events.Length > 0){
				foreach(var t in events){
					t.time = clipLength - t.time;
				}

				AnimationUtility.SetAnimationEvents(clip, events);
			}
			
		}

		[MenuItem("Assets/Create Reversed Clip", true)]
		private static bool ReverseClipValidation(){
			return Selection.activeObject is AnimationClip;
		}

		private static AnimationClip GetSelectedClip(){
			var clips = Selection.GetFiltered(typeof(AnimationClip), SelectionMode.Assets);
			if(clips.Length > 0){
				return clips[0] as AnimationClip;
			}

			return null;
		}
	}
	#endif
	
}