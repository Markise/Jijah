using UnityEngine;
using System.Collections;

public class FireBallLeftAngle : MonoBehaviour {

	public int skillLvl;
	public float dmgValue;
	public float endDistance;
	public float moveSpeed;
	public GameObject FireBallExpl;
	public PlayerController player;

	private GameObject Monster;
	private float moveDist;
	private Vector3 pos;
	private Vector3 explodePos;
	private bool spawned;

	// Use this for initialization
	void Start () {
		spawned = false;
		player = FindObjectOfType<PlayerController> ();

		if (player.transform.localScale.x < 0) {
			moveSpeed = -moveSpeed;
		}
		pos = GetComponent<Rigidbody> ().position;

		dmgValue = 2;

	}

	// Update is called once per frame
	void Update () {

		moveDist = Vector3.Distance(pos,transform.position);
		GetComponent<Rigidbody> ().velocity = new Vector3 (moveSpeed, GetComponent<Rigidbody> ().velocity.y, moveSpeed);
		if(spawned == false)
		{
			if (moveDist >= endDistance) 
			{
				spawned = true;
				explodePos = new Vector3 (GetComponent<Rigidbody> ().position.x,GetComponent<Rigidbody>().position.y-0.54f, GetComponent<Rigidbody> ().position.z);
				Instantiate (FireBallExpl, explodePos, transform.rotation);
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter (Collider other){

		if (other.tag == "Enemy") {
			other.GetComponent<MonsterHealth> ().giveDamage (dmgValue);
		

			if (spawned == false) {
				spawned = true;
				explodePos = new Vector3 (GetComponent<Rigidbody> ().position.x, GetComponent<Rigidbody>().position.y-0.54f, GetComponent<Rigidbody> ().position.z);
				Instantiate (FireBallExpl, explodePos, transform.rotation);
				Destroy (gameObject);
			}
		}
	}
}
