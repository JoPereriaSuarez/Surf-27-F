using System;
using System.Collections;
using System.Collections.Generic;

public class MyChoose <T>
{
	public T value
	{
		get; private set;
	}

	// Constructors
	public MyChoose(List<T> theList)
	{
		int index = UnityEngine.Random.Range(0, theList.Capacity);
		value = theList[index];
	}
	public MyChoose(T[] theArray)
	{
		List<T> theList = new List<T>(theArray);
		int index = UnityEngine.Random.Range(0, theList.Capacity -1);
		value = theList[index];
	}
}
