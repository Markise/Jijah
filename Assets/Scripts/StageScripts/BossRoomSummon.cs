using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomSummon : MonoBehaviour {

    public GameObject Stage;//with wall
    public GameObject stgPoint;
    private int stgDirection;
    private bool stgSpawned;
    // Use this for initialization
    void Start()
    {

        stgSpawned = false;

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            if (PlayerController.action == true)
            {
                if (stgSpawned == false)
                {
                    Instantiate(Stage, stgPoint.transform.position, Quaternion.Euler(90f, 0f, 90f));
                    stgSpawned = true;
                    //player.transform.position = stgPoint.transform.position;
                }
            }
        }
    }
}
