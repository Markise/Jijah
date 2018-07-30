using UnityEngine;
using System.Collections;

public class FireSwipe : MonoBehaviour {

	public int skillLvl;
	public float dmgValue;
	public float endDistance;
	public float moveSpeed;
	public GameObject FireBall;
	public GameObject FireBallR;
	public GameObject FireBallL;
	public PlayerController player;

	private float scaleX;
	private GameObject Monster;
	private float moveDist;
	private Vector3 explodePos;
	private bool spawned;

	// Use this for initialization
	void Start () {
		spawned = false;
		player = FindObjectOfType<PlayerController> ();

		scaleX = transform.localScale.x;

		if (player.transform.localScale.x < 0) {

			transform.localScale = new Vector3 (-scaleX, transform.localScale.y, -transform.localScale.z);

		}

		dmgValue = 4;

	}

	// Update is called once per frame
	void Update () {
		if (player.transform.localScale.x < 0) {

			transform.localScale = new Vector3 (-scaleX, transform.localScale.y, transform.localScale.z);

		}

	/*	moveDist = Vector3.Distance(pos,transform.position);
		//GetComponent<Rigidbody> ().velocity = new Vector3 (moveSpeed, GetComponent<Rigidbody> ().velocity.y, GetComponent<Rigidbody> ().velocity.z);
		if(spawned == false)
		{
				spawned = true;
				explodePos = new Vector3 (GetComponent<Rigidbody> ().position.x,GetComponent<Rigidbody>().position.y, GetComponent<Rigidbody> ().position.z);
				Instantiate (FireBall, explodePos, transform.rotation);
				Instantiate (FireBallR, explodePos, transform.rotation);
				Instantiate (FireBallL, explodePos, transform.rotation);
				


		}*/
	}

	void OnTriggerEnter (Collider other){

		if (other.tag == "Enemy") 
		{
			other.GetComponent<MonsterHealth> ().giveDamage (dmgValue);

		/*	if (spawned == false) 
			{
				spawned = true;
				explodePos = new Vector3 (GetComponent<Rigidbody> ().position.x, GetComponent<Rigidbody>().position.y, GetComponent<Rigidbody> ().position.z);
				Instantiate (FireBall, explodePos, transform.rotation);
				Instantiate (FireBallR, explodePos, transform.rotation);
				Instantiate (FireBallL, explodePos, transform.rotation);


			}*/
		}


	/*	if (other.tag == "BrkRock") 
		{
			Destroy (gameObject);
		}*/
	}
}
