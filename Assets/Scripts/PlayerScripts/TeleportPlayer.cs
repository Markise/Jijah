using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour {

    private GameObject ReturnPoint;
    private GameObject NextPoint;
    private GameObject StartPoint;
    public static bool teleported;

    private bool levelTeleported;
    // Use this for initialization
    void Start()
    {
        levelTeleported = false;   
        if (LevelManager.stageNum == 0)
        {
            StartPoint = GameObject.FindGameObjectWithTag("EntrancePoint");
            transform.position = StartPoint.transform.position;

        }
        teleported = true;
    }

    // Update is called once per frame
    void Update () {
        if (LevelManager.stageNum == 0)
         {
             StartPoint = GameObject.FindGameObjectWithTag("EntrancePoint");
             transform.position = StartPoint.transform.position;

         }
 
        if (BackStageTeleporter.entering == true)
        {
            NextPoint = GameObject.FindGameObjectWithTag("EntrancePoint");
            transform.position = NextPoint.transform.position;
            BackStageTeleporter.entering = false;
            BackStageTeleporter.counted = false;
            teleported = true;
        }

        if(NextStageTeleporter.exiting == true)
        {
            ReturnPoint = GameObject.FindGameObjectWithTag("ExitPoint");
            transform.position = ReturnPoint.transform.position;
            NextStageTeleporter.exiting = false;

            teleported = true;
        }

	}

}
