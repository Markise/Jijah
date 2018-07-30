using UnityEngine;
using System.Collections;

public class RockSpawn : MonoBehaviour {

	public GameObject Rock;
	public GameObject BrkRock;
	public static int numOfRocks;

	private int brkRockChance;
	private bool spawnedRocks;
	private int rockPosX;
	private int getZPos;
	private float RockPosZ;
	private Vector3 rockPos;
	void Start ()
	{
        SpawnRocks();
        spawnedRocks = true;
    }

	public void SpawnRocks()
	{
		numOfRocks = Random.Range (15,20);


		for(int x = 0; x<numOfRocks;x++)
		{
			rockPosX = Random.Range (1,28);
			getZPos = Random.Range (1,6);


			if( getZPos == 1 )
			{
				RockPosZ = .27f;
			}
			if( getZPos == 2 )
			{
				RockPosZ = .77f;
			}
			if( getZPos == 3 )
			{
				RockPosZ = -.27f;
			}
			if( getZPos == 4 )
			{
				RockPosZ = -.77f;
			}
			if (getZPos == 5) 
			{
				RockPosZ = 1.27f;
			}

		/*	if (StageCounter.inverse == true) 
			{
				rockPosX = -rockPosX;
			}*/
				
			rockPos = new Vector3 (transform.position.x + rockPosX, transform.position.y, transform.position.z + RockPosZ);

			brkRockChance = Random.Range (0, 10);

			if (brkRockChance == 0 || brkRockChance == 1) 
			{
				Instantiate (BrkRock, rockPos, Quaternion.Euler (0f, 0f, 0f));
			}
			else{Instantiate(Rock,rockPos,Quaternion.Euler(0f,0f,0f));}

		}

	}

}
 