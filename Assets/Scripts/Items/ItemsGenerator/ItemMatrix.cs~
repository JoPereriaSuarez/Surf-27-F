using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ItemMatrix : MonoBehaviour
{
	public int 					badItems = 4;
	public int					goodItems = 4;

	// the generators GameObjects in the scene
	public 	Transform[] 		generators;
	private ItemGenerator[,] 	generatorMatrix;
	private List<List<int>> 	listFromTable;

	// the list of GameObjects in the Resources folder to be loaded
	internal GameObject[] 		obstacleResources
	{
		get; private set;
	}
	internal GameObject[] 		hazardResources
	{
		get; private set;
	}
		
	#region MATRIX INITIALIZATION
	// Create everything on start
	void Awake()
	{
		LoadMatrixResources();
		generatorMatrix = new ItemGenerator[3,4];
		listFromTable = new List<List<int>>(generatorMatrix.Length);

		int counter = 0;

		for (int i = 0; i < generatorMatrix.GetLength(0); i++) 
		{
			for (int j = 0; j < generatorMatrix.GetLength(1); j++) 
			{

				generatorMatrix[i,j] = generators[counter].
					GetComponent(typeof(ItemGenerator)) as ItemGenerator;
				counter ++;
			}
		}

		//MatrixCreator(goodItems, badItems);
		//InstantiateMatrix();

	}

	// Initialize the List From the Matrix and set the value of every item in it
	public void MatrixCreator(int good, int bad)
	{
		listFromTable = new List<List<int>>(generatorMatrix.Length);
		List<int> sublist;
		int[] values = new int[2];

		for (int i = 0; i < generatorMatrix.GetLength(0); i++) 
		{
			for (int j = 0; j < generatorMatrix.GetLength(1); j++) 
			{
				values [0] = i;
				values [1] = j;

				sublist = new List<int>(values);

				listFromTable.Add(sublist);
			}
		}

		CreateBadItems(bad);
		//CreateItems(bad, ItemType.bad);
		CreateItems(good, ItemType.good);
	}
	#endregion

	#region SET MATRIX'S ELEMENTS
	/// <summary>
	/// Creates the bad items.
	/// </summary>
	/// <param name="n">N.</param>
	void  CreateBadItems(int n)
	{
		List<int> sublist;
		int _number = n;
		List<int> testList;
		MyChoose<List<int>> choose;
		while(_number -- > 0)
		{
			testList = new List<int>(new int[]{0,1,2});
			choose = new MyChoose<List<int>>(listFromTable);
			testList.Remove(choose.value[0]);
			sublist = choose.value;
			testList.TrimExcess();
			int n2 = 0;
			while(n2++ <= 1)
			{
				sublist = choose.value;
				if(generatorMatrix[testList[1], choose.value[1]].itemType != ItemType.bad &&
					generatorMatrix[testList[0], choose.value[1]].itemType != ItemType.bad)
				{
					// Set Values
					generatorMatrix[sublist[0], sublist[1]].itemType = ItemType.bad;

					listFromTable.Remove(sublist);
					listFromTable.TrimExcess();	
					break;
		
				}
				else
				{
					listFromTable.Remove(sublist);
					listFromTable.TrimExcess();
				}
			}
		}
	}

	/// <summary>
	/// Creates the items.
	/// </summary>
	/// <param name="bad">Bad.</param>
	/// <param name="type">Type.</param>
	void CreateItems(int number, ItemType type)
	{
		List<int> sublist;
		int _number = number;

		MyChoose<List<int>> choose;

		while(_number-- > 0)
		{
			choose = new MyChoose<List<int>>(listFromTable);
			sublist = choose.value;

			// Set Values
			generatorMatrix[sublist[0], sublist[1]].itemType = type;

			listFromTable.Remove(sublist);
			listFromTable.TrimExcess();	
		}	
	}

	internal void ClearMatrix()
	{
		for(int i = 0; i < generatorMatrix.GetLength(0); i ++)
		{
			for(int j = 0; j < generatorMatrix.GetLength(1); j ++)
			{
				generatorMatrix[i,j].itemType = ItemType.empty;
			}
		}
	}
	#endregion

	#region LOADING AND INSTANTIATING
	/// <summary>
	/// Clears up resources.
	/// </summary>
	void ClearUpResources()
	{ 
		Array.Clear(obstacleResources, 0, obstacleResources.Length);
		Array.Clear(hazardResources, 0, hazardResources.Length);
	}

	/// <summary>
	/// Loads the matrix resources.
	/// </summary>
	void LoadMatrixResources()
	{
		obstacleResources = Resources.LoadAll<GameObject>("ObstaclesResources");
		hazardResources = Resources.LoadAll<GameObject>("HazardsResources");
	}

	/// <summary>
	/// Instantiates the matrix.
	/// </summary>
	public void InstantiateMatrix(bool good = true, bool bad = true)
	{
		ItemGenerator generator;
		GameObject ori;
		Vector3 pos = new Vector3(0,0,0);
		int rn;

		for (int i = 0; i < generatorMatrix.GetLength(0); i++) 
		{
			for(int j = 0; j < generatorMatrix.GetLength(1); j ++)	
			{
				if(generatorMatrix[i,j].itemType == ItemType.empty)
				{
					continue;
				}

				generator = generatorMatrix[i,j];
				pos.x = generator.transform.position.x;
				pos.y = generator.transform.position.y;

				if(generator.itemType == ItemType.bad && bad)
				{
					rn = UnityEngine.Random.Range(0, obstacleResources.Length);
					ori = obstacleResources[rn];
					pos.z = ori.transform.position.z;

					GameObject _obj = Instantiate(original: ori, position: pos, rotation: Quaternion.identity);
					_obj.GetComponent<SpriteRenderer>().enabled = true;

				}
				else if(generator.itemType == ItemType.good && good)
				{
					// Instantiate good
					rn = UnityEngine.Random.Range(0, hazardResources.Length);
					ori = hazardResources[rn];
					pos.z = ori.transform.position.z;

					GameObject _obj = Instantiate(original: ori, position: pos, rotation: Quaternion.identity);
					_obj.GetComponent<SpriteRenderer>().enabled = true;
				}
			}
		}

		ClearMatrix();
	}
	#endregion
}
