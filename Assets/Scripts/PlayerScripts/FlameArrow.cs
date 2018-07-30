using UnityEngine;
using System.Collections;

public class FlameArrow : MonoBehaviour {


	public int skillLvl;
	public float dmgValue;
	public float endDistance;
	public float moveSpeed;
	public GameObject FireBallExpl;
	public PlayerController player;

	private int hitCounter;
	private GameObject Monster;
	private float scaleX;
	private float moveDist;
	private Vector3 pos;
	private Vector3 explodePos;
	private bool spawned;
	private bool paused;

	// Use this for initialization
	void Start () {
		scaleX = transform.localScale.x;
		spawned = false;
		player = FindObjectOfType<PlayerController> ();

		if (player.transform.localScale.x < 0) {
			moveSpeed = -moveSpeed;
			transform.localScale = new Vector3 (-scaleX, transform.localScale.y, transform.localScale.z);

		
		}
		pos = GetComponent<Rigidbody> ().position;

		dmgValue = 6;

	}

	// Update is called once per frame
	void Update () {

		moveDist = Vector3.Distance(pos,transform.position);

		GetComponent<Rigidbody> ().velocity = new Vector3 (moveSpeed, GetComponent<Rigidbody> ().velocity.y, GetComponent<Rigidbody> ().velocity.z);

			if (moveDist >= endDistance) 
			{
				Destroy (gameObject);

			}

	}

	void OnTriggerEnter (Collider other){
		
		if (other.tag == "Enemy") 
		{
			Instantiate (FireBallExpl, transform.position, transform.rotation);
			other.GetComponent<MonsterHealth> ().giveDamage (dmgValue);
			Destroy (gameObject);

		}

		if (other.tag == "BrkRock") 
		{
			Instantiate (FireBallExpl, transform.position, transform.rotation);
			Destroy (gameObject);
		}
		if(other.tag == "Rock")
		{
				Instantiate (FireBallExpl, transform.position, transform.rotation);
		}
	}


}
