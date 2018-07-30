using UnityEngine;
using System.Collections;

public class BasicMonsterMovement : MonoBehaviour {

	public int mstrLevel;
	public int expToGive;
	public float dmgValue;
	public float collisionMovePause;
	public float speed;
	public PlayerController player;
	public MonsterHealth monster;
	public static bool reversed;
	public bool OkToMove;

	private float kickbackValue;
	private int incomingDmg;
	private int monsterHP;
	private int hitAcrcy;
	private float scaleX;
	private float scaleY;
	private float scaleZ;


	private int damageRecieved;

	// Use this for initialization
	void Start () {

		scaleX = transform.localScale.x;
		scaleY = transform.localScale.y;
		scaleZ = transform.localScale.z;
		player = FindObjectOfType <PlayerController> ();
		monster = FindObjectOfType<MonsterHealth> ();
		OkToMove = true;

	}

	// Update is called once per frame
	void Update () 
	{


		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);//Stops the use of Rigidbody momentum

		if (OkToMove == true) {
			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, speed * Time.deltaTime); 
		}

		if (transform.position.x > player.transform.position.x) {
			transform.localScale = new Vector3 (scaleX, scaleY, scaleZ);
			reversed = false;
		} else {
			transform.localScale = new Vector3 (-scaleX,scaleY,scaleZ);
			reversed = true;
		}
	}

	void OnTriggerEnter(Collider other){


		if (other.tag == "Player") 
		{

			hitAcrcy =  Random.Range (0,2);

			if (hitAcrcy == 0) {
				dmgValue = mstrLevel * 4; 
			}
			if (hitAcrcy == 1) {
				dmgValue = mstrLevel * 6; 
			}

			other.GetComponent<PlayerStats>().HurtPlayer(dmgValue);

			//other.GetComponent<AudioSource> ().Play ();
			StartCoroutine(TouchPlayerPause());

		}
			
	}
		

	public IEnumerator TouchPlayerPause()
	{
		OkToMove = false;
		yield return new WaitForSeconds (collisionMovePause);
		OkToMove = true;
	}
		
}
