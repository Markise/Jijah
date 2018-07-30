using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonBoss : MonoBehaviour {

    public GameObject Boss;
    public GameObject HolePoint;
	// Use this for initialization
	void Start () {
        Instantiate(Boss, HolePoint.transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
