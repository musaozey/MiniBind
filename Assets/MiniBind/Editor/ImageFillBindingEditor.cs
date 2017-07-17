#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace MiniBind.Components
{
	[CustomEditor(typeof(ImageFillBinding))]
	public class ImageFillBindingEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			SerializedProperty prop = serializedObject.FindProperty("m_Script");
			GUI.enabled = false;
			EditorGUILayout.PropertyField(prop, true, new GUILayoutOption[0]);
			GUI.enabled = true;
			serializedObject.ApplyModifiedProperties();

			var myScript = target as ImageFillBinding;
			myScript.key = EditorGUILayout.TextField("Key", myScript.key);
			myScript.isAnimated = EditorGUILayout.Toggle("Is Animated", myScript.isAnimated);

			if (myScript.isAnimated)
			{
				myScript.animationLength = EditorGUILayout.Slider("Animation Length", myScript.animationLength, 0, 10);
			}
		}
	}
}
#endif