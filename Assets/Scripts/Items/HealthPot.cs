using UnityEngine;
using System.Collections;

public class HealthPot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player") 
		{
			if (PlayerController.action == true) {
				PlayerStats.playerHealth += 20;
				Destroy (gameObject);
			}
		}
	}
}
