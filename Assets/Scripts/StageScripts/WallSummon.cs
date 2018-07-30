using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSummon : MonoBehaviour {

    
    public GameObject[] WallPieces;
    public GameObject WallPoint;
    private int pieceAmnt;
    private int pieceNum;
    private int wallRotation;
    private int[] arrayOfInts;

    // Use this for initialization
    void Start () {

        pieceAmnt = Random.Range(2, 6);
        for(int x =0; x<pieceAmnt;x++)
        {
            pieceNum = Random.Range(0, 7);
            //make an array to stop doubles from happening
            Instantiate(WallPieces[pieceNum], WallPoint.transform.position, transform.rotation);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
