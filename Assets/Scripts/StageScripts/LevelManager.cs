using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public Text Stgcount;
	public Text Lvlcount;

	public static int stageNum;
	public static int levelNum;
	// Use this for initialization
	void Start () {

		levelNum = 1;
		stageNum = 0;
	}
	
	// Update is called once per frame
	void Update () {

		//Stgcount.text = "" + stageNum;
		//Lvlcount.text = "" + levelNum;

		if (stageNum > 6)
		{
			levelNum +=1;
			stageNum = 0;
		}
			
	}
}
