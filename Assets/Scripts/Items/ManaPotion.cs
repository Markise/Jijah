using UnityEngine;
using System.Collections;

public class ManaPotion : MonoBehaviour {

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
			if (PlayerController.action == true)
			{
				PlayerStats.playerMana += 40;
				Destroy (gameObject);
			}
		}

	}
}
