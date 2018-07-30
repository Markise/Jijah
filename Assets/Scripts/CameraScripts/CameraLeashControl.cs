using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLeashControl : MonoBehaviour {

    public PlayerController player;
    public float speed;
    public float maxDist;

    private Vector3 plrStartPnt;
    private float plrDist;
    public bool onPlayerPos;

    // Use this for initialization
    void Start() {
        player = FindObjectOfType<PlayerController>();
        onPlayerPos = false;

    }
	// Update is called once per frame
	void Update () {

        if (onPlayerPos == false)
        {
            transform.position = player.transform.position;
           // onPlayerPos = true;
        }
        
        plrDist = Vector3.Distance(player.transform.position, transform.position);
       // Debug.Log(plrDist);

        if(plrDist >= maxDist)
        {
          // GetComponent<Rigidbody>().velocity = player.GetComponent<Rigidbody>().velocity;
           //Get the difference between the players initial position and its current position, and then use that to check if the player is moving or not
           //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
          // transform.position = Vector3.MoveTowards(transform.position, player.transform.position, );
        }
  

 	}
}
