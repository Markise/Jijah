using UnityEngine;
using System.Collections;

public class RockCheck : MonoBehaviour {

	private int numInRow;


	// Use this for initialization
	void Start () {
		numInRow = 0;
	}
	
	// Update is called once per frame
	void Update () {


	
	}
		
	void OnCollisionStay (Collision other)
	{

		if (other.collider.tag == "Rock")
		{
			numInRow += 1;
			if (other.transform.position.x == transform.position.x && other.transform.position.z == transform.position.z)
			{
				numInRow -= 1;
				RockSpawn.numOfRocks += 2;
				Destroy (other.gameObject);
			}

			if (numInRow >= 3)
			{
				Destroy (other.gameObject);
				Debug.Log ("Destroyed 4");
			}


		}
		if (other.collider.tag == "BrkRock") 
		{
			numInRow += 1;
			if (other.transform.position.x == transform.position.x && other.transform.position.z == transform.position.z)
			{
				numInRow -= 1;
				Destroy (other.gameObject);
			}
			if (numInRow >= 3)
			{
				Destroy (other.gameObject);
				Debug.Log ("Destroyed 4");
			}
		}
	
	}
}
