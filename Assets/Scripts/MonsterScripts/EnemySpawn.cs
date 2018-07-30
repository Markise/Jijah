using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public GameObject Monster;
    
    public TurnOffSpawn spawnOn;
	private int xAdd;
	private bool spawned;
	private int spawnNum;
	private float monXPos;
	private float monZPos;
	private Vector3 monPos;

	// Use this for initialization
	void Start () {

        spawnOn = FindObjectOfType<TurnOffSpawn>();
		spawned = false;
	
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
            if (spawnOn.enemyOn == true)
            {
                if (spawned == false)
                {
                    Spawn();
                    spawned = true;
                }
            }
		}
	}

	public void Spawn()
	{
		xAdd = +1;
		spawnNum =	Random.Range (3,6);
		for (int x = 0; x < spawnNum; x++) 
		{
				
			monXPos = Random.Range(.3f,2.5f);
			monZPos = Random.Range (-1f, .5f);

		/*	if (StageCounter.inverse == true) {
				monXPos = -monXPos;
				xAdd = -1;
			} */

			monPos = new Vector3 (transform.position.x + xAdd + monXPos, transform.position.y, transform.position.z + monZPos);

			Instantiate (Monster, monPos, transform.rotation);
		}

	}

}
