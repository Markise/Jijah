using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {


	public Text HpCounter;
	public Text MpCounter;
	public Text ExpCounter;
	public Text LevelCounter;
	public Text Stgcount; 
	public Text Lvlcount;

	public float maxPlayerHealth;
	public int maxPlayerMana;
	public static int playerHealth;
	public static int playerMana;
	public static int playerLevel;
	public int expNeeded;
	public static int expEarned;
	public float holdDmg;

	private float kickBack;
	private bool isDead;
	private bool plrLvled;

	
	// Use this for initialization
	void Start () {


		playerLevel = 1;

		plrLvled = false;
		isDead = false;

		playerHealth = Mathf.CeilToInt(maxPlayerHealth);
		playerMana = maxPlayerMana;

	}
	
	// Update is called once per frame
	void Update () {

		if (playerHealth >= maxPlayerHealth) 
		{
			playerHealth =Mathf.CeilToInt(maxPlayerHealth);
		}
		if (playerHealth <= 0) 
		{
			playerHealth = 0;
		}

		if (playerMana >= maxPlayerMana) 
		{
			playerMana = maxPlayerMana;
		}
		if (playerMana <= 0)
		{
			playerMana = 0;
		}


		HpCounter.text ="" + playerHealth;
		MpCounter.text ="" + playerMana;
		ExpCounter.text ="" + expEarned+ " / " + expNeeded;
		LevelCounter.text ="" + playerLevel;
        if (LevelManager.stageNum == 6)
        {
            Stgcount.text = "B";
        }
        else
        {
            Stgcount.text = "" + LevelManager.stageNum;
        }
		Lvlcount.text = "" + LevelManager.levelNum;


		expNeeded = ((playerLevel + 1) * 200) - 150;


		if (expEarned >= expNeeded)
		{
			expEarned = 0;
			playerLevel += 1;
			plrLvled = true;
		}


		if (playerLevel != 1 && plrLvled == true) {
			maxPlayerHealth += Mathf.CeilToInt((1.2f * playerLevel) * 12);
			playerHealth = Mathf.CeilToInt(maxPlayerHealth);
		}

		if (playerLevel != 1 && plrLvled == true) {
			maxPlayerMana += Mathf.CeilToInt((1.2f * playerLevel) * 10);
			playerMana = maxPlayerMana;

		}

		plrLvled = false;

		if (playerHealth <= 0) {
			playerHealth = 0;
			Destroy (gameObject);
			isDead = true;
		}

	
	}

	public void HurtPlayer(float dmgToGive)
	{
		holdDmg = dmgToGive;
		playerHealth -= Mathf.CeilToInt(holdDmg);

		kickBack = (holdDmg / maxPlayerHealth);
		if (PlayerController.reversed == true) 
		{
			transform.Translate (kickBack+.1f, 0, 0, Space.World);
		}
		if (PlayerController.reversed == false) 
		{
			transform.Translate (-kickBack-.1f, 0, 0, Space.World);
		}





	}
	public static void Experience( int expToGive)
	{
		expEarned += expToGive;

	}
}
