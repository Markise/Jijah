using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPlayer : MonoBehaviour {

    public PlayerController player;
	// Use this for initialization
	void Start () {

      player = FindObjectOfType<PlayerController>();

        player.transform.position = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
