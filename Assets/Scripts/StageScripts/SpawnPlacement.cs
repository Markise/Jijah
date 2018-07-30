using UnityEngine;
using System.Collections;

public class SpawnPlacement : MonoBehaviour {


	public GameObject Spawn1;
	public GameObject Spawn2;
	public GameObject Spawn3;
	public GameObject Spawn4;
	public GameObject Spawn5;
	public GameObject Spawn6;
	public GameObject smlSpawn1;
	public GameObject smlSpawn2;
	public GameObject smlSpawn3;
	public GameObject smlSpawn4;
	public GameObject smlSPawn5;
	public GameObject smlSPawn6;

	private int spwnSelect;
	private int spwnNumber;

	private bool spwn1;
	private bool spwn2;
	private bool spwn3;
	private bool spwn4;
	private bool spwn5;
	private bool spwn6;


	// Use this for initialization
	void Start () {


		Spawn1.SetActive(false);
		Spawn2.SetActive(false);
		Spawn3.SetActive(false);
		Spawn4.SetActive(false);
		Spawn5.SetActive(false);
		Spawn6.SetActive(false);

		spwn1 = false;
		spwn2 = false;
		spwn3 = false;
		spwn4 = false;
		spwn5 = false;
		spwn6 = false;

		Spawn ();
	}
	
	// Update is called once per frame
	void Update () {

	
			
		}

	public void Spawn()
	{

		//spwnNumber = Random.Range (3, 4);
		spwnNumber = 3;
		for (int x = 0; x < spwnNumber; x++)//GroupSpawns
		{
			spwnSelect = Random.Range (1, 7);


			if (spwnSelect == 1) {
				if (spwn1 == false) {
					Spawn1.SetActive (true);
					spwn1 = true;
				} else if (spwn1 == true) {
					spwnNumber += 1;
				}
			}

			if (spwnSelect == 2) {
				if (spwn2 == false) {
					Spawn2.SetActive (true);
					spwn2 = true;
				} else if (spwn2 == true) {
					spwnNumber += 1;
				}
			}
			if (spwnSelect == 3) {
				if (spwn3 == false) {
					Spawn3.SetActive (true);
					spwn3 = true;
				} else if (spwn3 == true) {
					spwnNumber += 1;
				}
			}
			if (spwnSelect == 4) {
				if (spwn4 == false) {
					Spawn4.SetActive (true);
					spwn4 = true;
				} else if (spwn4 == true) {
					spwnNumber += 1;
				}
			}
			if (spwnSelect == 5) {
				if (spwn5 == false) {
					Spawn5.SetActive (true);
					spwn5 = true;
				} else if (spwn5 == true) {
					spwnNumber += 1;
				}
			}
			if (spwnSelect == 6) {
				if (spwn6 == false) {
					Spawn6.SetActive (true);
					spwn6 = true;
				} else if (spwn6 == true) {
					spwnNumber += 1;
				}
			}
		}
	}
		
}
