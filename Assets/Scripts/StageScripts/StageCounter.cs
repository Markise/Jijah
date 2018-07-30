using UnityEngine;
using System.Collections;

public class StageCounter : MonoBehaviour {

	private bool counted;
	// Use this for initialization
	void Start ()
    {
        
		counted = false;
	}

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerStay(Collider other)
    {
/*        //If you want the player to start on a stage
 *        if (other.tag == "Player" && LevelManager.stageNum == 0)
        {
            LevelManager.stageNum++;
        }
*/
        if (other.tag == "Player")
        {
            if (PlayerController.action == true)
            {
                if (counted == false)
                {
                    TeleportPlayer.teleported = true;
                    LevelManager.stageNum++;
                    counted = true;
                }
            }     
                    
        }
    }
}
