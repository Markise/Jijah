using UnityEngine;
using System.Collections;

public class GravityOff : MonoBehaviour {

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
			other.GetComponent<Rigidbody> ().useGravity = false;
			other.GetComponent<Rigidbody> ().transform.position = new Vector3 (other.transform.position.x, transform.position.y, other.transform.position.z);
		}
	}
}
