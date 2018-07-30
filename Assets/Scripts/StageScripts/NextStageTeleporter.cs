using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStageTeleporter : MonoBehaviour {

    public GameObject EntrancePoint;
    private int stageNum;
    public static bool exiting;
 
    // Use this for initialization
    void Start ()
    {
        stageNum = LevelManager.stageNum;
        

        if (stageNum >= 6)
        {
            stageNum = 1;
        }
        stageNum -= 1;
        Debug.Log("NextSTGNum:" + stageNum);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (LevelManager.stageNum == 0 )
        {
            EntrancePoint.SetActive(true);
        } else if (LevelManager.stageNum == stageNum)
        {
            EntrancePoint.SetActive(true);
        }
        else { EntrancePoint.SetActive(false); }
	}
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && LevelManager.stageNum == 0)
        {
            LevelManager.stageNum++;
        }

        if (other.tag == "Player")
        {
            if (PlayerController.action == true)
            {
                exiting = true;
                LevelManager.stageNum = stageNum;          

            }
        }
    }
    }
