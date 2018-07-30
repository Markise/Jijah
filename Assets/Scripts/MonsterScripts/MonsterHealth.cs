using UnityEngine;
using System.Collections;

public class MonsterHealth : MonoBehaviour {


	public int mstrLevel;
	public int monsterHealth;
	public float maxMonsterHealth;
	public float playerAttackPause;
	public float holdDmg;

	private static float kickBack;
	private int expToGive;

	// Use this for initialization
	void Start () {


		maxMonsterHealth = mstrLevel * 10;
		monsterHealth = Mathf.CeilToInt(maxMonsterHealth);
	//	Debug.Log (monsterHealth);
		expToGive = mstrLevel * 6;
	}
	
	// Update is called once per frame
	void Update () {



		if (monsterHealth <= 0) {

			PlayerStats.Experience (expToGive);
			Destroy (gameObject);
		}

	
	}

	public void giveDamage(float dmgToGive)
	{
		holdDmg = dmgToGive;

		monsterHealth -= Mathf.CeilToInt(holdDmg);

		kickBack = (holdDmg / maxMonsterHealth)+.1f;
        
		if (BasicMonsterMovement.reversed == false) 
		{
			transform.Translate(kickBack,0,0);
		} else if (BasicMonsterMovement.reversed == true)
		{
			transform.Translate (-kickBack, 0, 0);
		}

		StartCoroutine (HitByPlayerPause ());
	//	Debug.Log (kickBack);

		//GetComponent<AudioSource> ().Play ();

	}

	public IEnumerator HitByPlayerPause()
	{
		
		GetComponent<BasicMonsterMovement>().OkToMove = false;
		yield return new WaitForSeconds (kickBack);
		GetComponent<BasicMonsterMovement>().OkToMove = true;


	}





}
