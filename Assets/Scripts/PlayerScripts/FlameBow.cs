using UnityEngine;
using System.Collections;

public class FlameBow : MonoBehaviour {

	public GameObject Arrow;
	public PlayerController player;
	public GameObject FirePoint;

	private float scaleX;

	private float xPos;
	private float zPos;
	private Vector3 playerPos;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();

		scaleX = transform.localScale.x;
		xPos = transform.position.x;
		zPos = transform.position.z;
		playerPos = player.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.localScale.x < 0) {

			transform.localScale = new Vector3 (-scaleX, transform.localScale.y, transform.localScale.z);
		} else if (player.transform.localScale.x > 0) 
		{
			transform.localScale = new Vector3 (scaleX, transform.localScale.y, transform.localScale.z);
		}

		transform.position = FirePoint.transform.position;
	}

}
