using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemMatrix))]
public class MatrixOnEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		ItemMatrix editorMatrix = (ItemMatrix)target;


		if(GUILayout.Button("Instantiate Items"))
		{
			editorMatrix.MatrixCreator(editorMatrix.goodItems, editorMatrix.badItems);
			editorMatrix.InstantiateMatrix();
			Debug.Log(editorMatrix.badItems + "," + editorMatrix.goodItems);
		}
	}
}
