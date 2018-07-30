using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossholeSummon : MonoBehaviour {

    public GameObject BossHole;
    public GameObject HolePoint;
	// Use this for initialization
	void Start () {

        Instantiate(BossHole, HolePoint.transform.position, Quaternion.Euler(90f, 0f, 90f));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
