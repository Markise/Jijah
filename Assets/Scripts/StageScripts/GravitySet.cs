using UnityEngine;
using System.Collections;

public class GravitySet : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") 
		{
			other.GetComponent<Rigidbody> ().useGravity = true;
		}
	}
}
