using UnityEngine;
using System.Collections;

public class RockBreak : MonoBehaviour {

	public GameObject Item1;
	public GameObject Item2;
	private int itemChance;
	private int damage;

	// Use this for initialization
	void Start () {
		damage = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (damage >= 3) 
		{
			itemChance = Random.Range (1,10);
			if (itemChance == 1 || itemChance == 2)
			{
				Instantiate (Item1, transform.position, transform.rotation);
			}
			if (itemChance == 3 || itemChance == 4) 
			{
				Instantiate (Item2, transform.position, transform.rotation);
			}
			Destroy (gameObject);
		}
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Attack") 
		{
			damage += 1;;
		}
	}
}
