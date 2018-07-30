using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStagePoint : MonoBehaviour {

    private int stagePlaceHolder;
    public int cameraStageNum;
    public static int firstRunCheck;
    
	// Use this for initialization
	void Start () {
        CameraStagePoint.firstRunCheck++;
        stagePlaceHolder = LevelManager.stageNum;

        if(CameraStagePoint.firstRunCheck == 1)
        {
            cameraStageNum = stagePlaceHolder+1;
        }
        else { cameraStageNum = stagePlaceHolder; }
       
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
