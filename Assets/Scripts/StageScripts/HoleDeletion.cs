using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleDeletion : MonoBehaviour {

    public GameObject Boss;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Boss.GetComponent<MonsterHealth>().monsterHealth <= 0)
        {
            Destroy(gameObject);
        }
       		
	}
}
