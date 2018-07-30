using UnityEngine;
using System.Collections;

public class LedgeCheck : MonoBehaviour {


	public GameObject Wall;

	private int collisionCount;
	private bool wallUp;
	// Use this for initialization
	void Start () {
		wallUp = false;
		collisionCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Stage") {
			collisionCount++;
			Debug.Log (collisionCount);
		}
		if (other.tag == "Player" && collisionCount == 0) {

			if (wallUp == false) {
				Instantiate (Wall, transform.position, Quaternion.Euler (0f, 0f, 0f));
				wallUp = true;
			}

			
		}
	}
}
