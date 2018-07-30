using UnityEngine;
using System.Collections;

public class NameStage : MonoBehaviour {

	private static int level;
	private static int stage;
	// Use this for initialization
	void Start () {
		level = LevelManager.levelNum;
		stage = LevelManager.stageNum;
	}
	
	// Update is called once per frame
	void Update () {

		if (LevelManager.levelNum > level + 2) 
		{
			Destroy (gameObject);

		}
	}
}
