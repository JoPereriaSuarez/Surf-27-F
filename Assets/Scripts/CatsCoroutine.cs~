using UnityEngine;
using System.Collections;

public class CatsCoroutine : MonoBehaviour
{
	ItemMatrix matrix;

	void Start()
	{
		matrix = GetComponent(typeof(ItemMatrix)) as ItemMatrix;

		StartCoroutine(cat_routine());
	}

	IEnumerator cat_routine()
	{
		yield return new WaitForSeconds(5);

		matrix.MatrixCreator(2,2);
		matrix.InstantiateMatrix();

		StartCoroutine(cat_routine());
	}
}
