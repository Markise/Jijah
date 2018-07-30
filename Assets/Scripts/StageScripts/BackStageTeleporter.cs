using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackStageTeleporter : MonoBehaviour {

    public static bool entering;
    public GameObject ExitPoint;
    private int stageNum;
    public static bool counted;

	// Use this for initialization
	void Start () {

        stageNum = LevelManager.stageNum;
        if(stageNum >= 6)
        {
            stageNum = 1;
        }
     
       
        Debug.Log("BackstageNum: " + stageNum);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (LevelManager.stageNum == stageNum+1)
        {
            ExitPoint.SetActive(true);
        }
        else { ExitPoint.SetActive(false); }
	}

    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            if (PlayerController.action == true)
            {
                if (counted != true)
                {
                    entering = true; 
                    LevelManager.stageNum = stageNum+1;
                    counted = true;
                }                

            }
        }
    }

}
