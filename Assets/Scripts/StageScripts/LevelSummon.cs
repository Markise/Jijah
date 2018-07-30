using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSummon : MonoBehaviour {

    public GameObject LevelPoint;
    public GameObject NextLevel;

    private GameObject[] allObjects;
    private bool lvlSummoned;

	// Use this for initialization
	void Start () {
        lvlSummoned = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (lvlSummoned == false)
            {
                LevelManager.stageNum++;
                Instantiate(NextLevel, LevelPoint.transform.position, Quaternion.Euler(90f, 0f, 90f));
                lvlSummoned = true;
                StartCoroutine(ClearLastLevel());
            }
        }
    }

    public IEnumerator ClearLastLevel()
    {
        yield return new WaitForSeconds(.15f);
        allObjects = GameObject.FindObjectsOfType<GameObject>();
        for (int x = 0; x < allObjects.Length; x++)
        {
            if (allObjects[x].transform.position.y > transform.position.y)
            {
                if (allObjects[x].tag != "MainCamera" && allObjects[x].tag != "Canvas")
                {
                    Destroy(allObjects[x]);
                }
            }
        }
    }
}
