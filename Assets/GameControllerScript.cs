using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {
	public GameObject cubePrefab;
	private GameObject[,] allCubes;
	public Airplane airplane;
	int numbCubes = 16;
	int numCubes = 9;

	// Use this for initialization
	void Start () {

		airplane = new Airplane ();
		airplane.x = 0;
		airplane.z = numCubes - 1;
		allCubes = new GameObject[numbCubes, numCubes];

		for (int x = 0; x < numbCubes; x++)	{
			for (int z = 0; z < numCubes; z++) {
				allCubes [x,z] = (GameObject)Instantiate (cubePrefab, new Vector3 (x * 2 -14, z * 2 - 14, 10), Quaternion.identity);
				allCubes [x,z].GetComponent<CubeBehavior>().x = x;
				allCubes [x,z].GetComponent<CubeBehavior>().z = z;
				allCubes [x,z].GetComponent<CubeBehavior>().GameController = this;
			}
		}
		allCubes[0,numCubes - 1].GetComponent<Renderer>().material.color = Color.red;
	}

	public void Location (GameObject oneCube)	{

		if (airplane.x == oneCube.GetComponent<CubeBehavior>().x && airplane.z == oneCube.GetComponent<CubeBehavior>().z 
		    && airplane.isActive == false)	{
			oneCube.GetComponent<Renderer>().material.color = Color.yellow;
			airplane.isActive = true;
		}

		else if (airplane.x == oneCube.GetComponent<CubeBehavior>().x && airplane.z == oneCube.GetComponent<CubeBehavior>().z
		                                                          && airplane.isActive == true)	{
			oneCube.GetComponent<Renderer>().material.color = Color.red;
			airplane.isActive = false;
		}

		else if (airplane.isActive == true && (airplane.x != oneCube.GetComponent<CubeBehavior>().x || 
		    airplane.z != oneCube.GetComponent<CubeBehavior>().z))	{
			allCubes [airplane.x, airplane.z].GetComponent<Renderer>().material.color = Color.white;
			airplane.x = oneCube.GetComponent<CubeBehavior>().x;
			airplane.z = oneCube.GetComponent<CubeBehavior>().z;
			allCubes [airplane.x, airplane.z].GetComponent<Renderer>().material.color = Color.yellow;
			airplane.isActive = true;
			}
	}

	// Update is called once per frame
	void Update () {
	
	}
}