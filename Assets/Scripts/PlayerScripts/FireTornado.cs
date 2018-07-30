using UnityEngine;
using System.Collections;

public class FireTornado : MonoBehaviour {

	public GameObject FireBallExpl;
	public float dmgValue;
	public float rotationSpeed;
	public float endDistance;
	public float moveSpeed;
	public PlayerController player;

	private int hits;
	private Vector3 pos;
	private float moveDist;
	private float scaleX;
	private bool hitSomething;

	// Use this for initialization
	void Start () 
	{
		hits = 0;
		hitSomething = false;
		pos = GetComponent<Rigidbody> ().position;
		scaleX = transform.localScale.x;
		player = FindObjectOfType<PlayerController> ();
		if (player.transform.localScale.x < 0) {
			moveSpeed = -moveSpeed;
			transform.localScale = new Vector3 (-scaleX, transform.localScale.y, transform.localScale.z);
		}

		dmgValue = 2;
	}

	// Update is called once per frame
	void Update ()
	{
		if (hitSomething == true) {
			GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 0f, 0f);
		} else if (hitSomething == false)
		{
			GetComponent<Rigidbody> ().velocity = new Vector3 (moveSpeed, GetComponent<Rigidbody> ().velocity.y, GetComponent<Rigidbody> ().velocity.z);
		}
		moveDist = Vector3.Distance (pos, transform.position);

		if (moveDist >= endDistance) 
		{
			if(hitSomething == false)
			{
				Destroy (gameObject);
			}
		}
			
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Enemy") 
		{
			hitSomething = true;
			Instantiate (FireBallExpl, transform.position, transform.rotation);
			other.GetComponent<MonsterHealth> ().giveDamage (dmgValue);
			GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 0f, 0f);
			moveSpeed = 0f;
		}
		if (other.tag == "Rock") 
		{
			hitSomething = true;
			Instantiate (FireBallExpl, transform.position, transform.rotation);
			GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 0f, 0f);
			moveSpeed = 0f;

		}
		if (other.tag == "BrkRock") 
		{
			hitSomething = true;
			Instantiate (FireBallExpl, transform.position, transform.rotation);
			GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 0f, 0f);
			moveSpeed = 0f;
		}
	
			
	}
}
