using UnityEngine;
using System.Collections;

public class PlayerAttcks : MonoBehaviour {

	public GameObject FirePoint;
	public GameObject FireSwipe;
	public GameObject FireArrow;
	public GameObject FireTornado;
	public Sprite FlameBowSprite;
	public Sprite JijahSprite;

	public int mpCost;
	public int skillLvl;

	private bool fired;
	private bool fSwipeIsCharged;
	private bool fBowIsCharged;
	private bool oktofireFB;
	private bool fTornadoCharged;


	// Use this for initialization
	void Start () {
		
		fired = false;
		fBowIsCharged = true;
		oktofireFB = false;
		fSwipeIsCharged = true;
		fTornadoCharged = true;
		skillLvl = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		mpCost = 0;

		/*******************************FireSwipe******************************
		 * 
		 * 
		 */
		if (Input.GetKeyDown (KeyCode.J))//FireSwipe
		{
			if (fired == false) 
			{
				StartCoroutine (Fired ());
				fired = true;
				if (skillLvl == 1) 
				{
					mpCost = 4;
				} else
				{
					mpCost = Mathf.CeilToInt (4 + ((skillLvl + 1) * .08f));
				}
				if (fSwipeIsCharged == true) 
				{
					if (PlayerStats.playerMana >= mpCost) 
					{ 
						fSwipeIsCharged = false;
						PlayerStats.playerMana -= mpCost;
						Instantiate (FireSwipe, FirePoint.transform.position, transform.rotation);
						StartCoroutine (FireSwipeCharge ());
					}

				}
			}
		}
		//*******************************FireSwipe******************************



		/*******************************FlameBow******************************
		 * 
		 *
		 */
		if(Input.GetKey(KeyCode.K))//FlameBow
		{
			if (fired == false)
			{
				fired = true;
				StartCoroutine (Fired ());
				if (skillLvl == 1) 
				{
					mpCost = 5;
				} else {
					mpCost = Mathf.CeilToInt (5 + ((skillLvl + 1) * .08f));
				}
				if (fBowIsCharged == true)
				{
					if (PlayerStats.playerMana >= mpCost) 
					{ 
						GetComponent<SpriteRenderer>().sprite = FlameBowSprite;
						oktofireFB = true;
						fBowIsCharged = false;
						PlayerStats.playerMana -= mpCost;

					}
				}
			}

		}
		if (Input.GetKeyUp (KeyCode.K))//FlameBow
		{
			if (oktofireFB == true) 
			{
				GetComponent<SpriteRenderer> ().sprite = JijahSprite;
				Instantiate (FireArrow, FirePoint.transform.position, transform.rotation);
				oktofireFB = false;
				StartCoroutine (FireBowCharge ());
			}

		}
		//*******************************FlameBow******************************



		/***************************FireTornado******************************
		 * 
		 * 
		 */
		if (Input.GetKeyDown (KeyCode.L))//FireTornado
		{
			if (fired == false) 
			{
				fired = true;
				if (skillLvl == 1) 
				{
					mpCost = 8;
				} else {
					mpCost = Mathf.CeilToInt (8 + ((skillLvl + 1) * .08f));
				}
					
				if (fTornadoCharged == true) 
				{
					if (PlayerStats.playerMana >= mpCost) 
					{ 
						
						fTornadoCharged = false;
						PlayerStats.playerMana -= mpCost;
						Instantiate (FireTornado, FirePoint.transform.position, Quaternion.Euler(90f,0,0));
						StartCoroutine (FireTornadoCharge ());
					}
				}
				StartCoroutine (Fired ());
			}
		}
		//***************************FireTornado****************************** 
		 


		/*******************************UltimateAttack******************************
		 * 
		 * 
		 */
		if (Input.GetKeyDown (KeyCode.I)) //UltimateAttack
		{
			if (fired == false)
			{
				fired = true;


				StartCoroutine (Fired ());
			}
		}
	
	}

	public IEnumerator Fired ()
	{
		yield return new WaitForSeconds (.3f);
		fired = false;

	}
	public IEnumerator FireSwipeCharge()
	{
		yield return new WaitForSeconds (.2f);
		fSwipeIsCharged = true;

	}

	public IEnumerator FireBowCharge()
	{
		yield return new WaitForSeconds (.3f);
		fBowIsCharged = true;
	}

	public IEnumerator FireTornadoCharge()
	{
		yield return new WaitForSeconds (.4f);
		fTornadoCharged = true;
	}
}
