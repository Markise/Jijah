using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject CameraPoint;
    public GameObject[] CameraPoints;
	public PlayerController player;
    public static bool isFollowingZ;

	public float xOffSet;
	public float yOffSet;
	public float zOFfSet;
    

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
      
        MoveCamera();
	}

	void Update () {

        transform.position = new Vector3(player.transform.position.x + xOffSet, player.transform.position.y + yOffSet, transform.position.z + zOFfSet);

        if (TeleportPlayer.teleported == true)
        {
            MoveCamera();
            TeleportPlayer.teleported = false;
        }
        
    }

    public void MoveCamera()
    {
        CameraPoints = GameObject.FindGameObjectsWithTag("CameraZPoint");
        for (int x = 0; x < CameraPoints.Length; x++)
        {
            CameraPoint = CameraPoints[x];

            if (CameraPoint.GetComponent<CameraStagePoint>().cameraStageNum == LevelManager.stageNum)
            {
                transform.position = new Vector3(player.transform.position.x + xOffSet, player.transform.position.y + yOffSet, CameraPoint.transform.position.z + zOFfSet);
            }
        }

    }

}
