using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(GameController))]
public class GameControllerOnEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		GameController _controller = (GameController)target;


		if(GUILayout.Button("Instantiate Items"))
		{
			_controller.StartNumberOfItems(_controller.dificulty);
		}
	}
}

