using UnityEngine;
using System.Collections;

public class ExplosionDmg : MonoBehaviour {

	public int dmgValue;
	// Use this for initialization
	void Start () {
		 
		dmgValue = 1;
	}
	
	// Update is called once per frame 
	void Update () {
	
	}

	void OnTriggerEnter (Collider other){

		if (other.tag == "Enemy") {
			other.GetComponent<MonsterHealth> ().giveDamage (dmgValue);
		}
	}
}
