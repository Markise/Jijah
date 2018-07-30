using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpawning : MonoBehaviour {

   
    public GameObject TopDoor;
    public GameObject BottomDoor;
    public GameObject BackTopDoor;
    public GameObject BackBottomDoor;
    public GameObject TopBossDoor;
    public GameObject BottomBossDoor;
    public GameObject TopSpawn1;
    public GameObject TopSpawn2;
    public GameObject TopSpawn3;
    public GameObject TopSpawn4;
    public GameObject BottomSpawn1;
    public GameObject BottomSpawn2;
    public GameObject BottomSpawn3;
    public GameObject BottomSpawn4;

    public static bool topDoor;

    private int spawnBoss;
    private int spawnPos;
    private int spawnPos2;

    // Use this for initialization
    void Start () {

        spawnPos = Random.Range(1, 9);
        Debug.Log(spawnPos);
        do
        {
            if (topDoor == true)
            {
                spawnPos2 = Random.Range(5, 9);
            }
            else { spawnPos2 = Random.Range(1, 5); }

        }while (spawnPos == spawnPos2);

        if (LevelManager.stageNum == 5)
        {
            SpawnBossDoors();
        }
        else { SpawnDoors(); }
        SpawnBackDoors();
        
    }

    public void SpawnDoors()
    {
               
            switch (spawnPos)
            {
                case 1:
                    Instantiate(TopDoor, TopSpawn1.transform.position, Quaternion.identity);
                    topDoor = true;
                    break;
                case 2:
                    Instantiate(TopDoor, TopSpawn2.transform.position, Quaternion.identity);
                    topDoor = true;
                    break;
                case 3:
                    Instantiate(TopDoor, TopSpawn3.transform.position, Quaternion.identity);
                    topDoor = true;
                    break;
                case 4:
                    Instantiate(TopDoor, TopSpawn4.transform.position, Quaternion.identity);
                    topDoor = true;
                    break;
                case 5:
                    Instantiate(BottomDoor, BottomSpawn1.transform.position, Quaternion.Euler(0f, 180f, 0f));
                    topDoor = false;
                    break;
                case 6:
                    Instantiate(BottomDoor, BottomSpawn2.transform.position, Quaternion.Euler(0f, 180f, 0f));
                    topDoor = false;
                    break;
                case 7:
                    Instantiate(BottomDoor, BottomSpawn3.transform.position, Quaternion.Euler(0f, 180f, 0f));
                    topDoor = false;
                    break;
                case 8:
                    Instantiate(BottomDoor, BottomSpawn4.transform.position, Quaternion.Euler(0f, 180f, 0f));
                    topDoor = false;
                    break;

            }
        
    }
 

    void SpawnBossDoors()
    {
        switch (spawnPos)
        {
            case 1:
                Instantiate(TopBossDoor, TopSpawn1.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(TopBossDoor, TopSpawn2.transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(TopBossDoor, TopSpawn3.transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(TopBossDoor, TopSpawn4.transform.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(BottomBossDoor, BottomSpawn1.transform.position, Quaternion.Euler(0f, 180f, 0f));
                break;
            case 6:
                Instantiate(BottomBossDoor, BottomSpawn2.transform.position, Quaternion.Euler(0f, 180f, 0f));
                break;
            case 7:
                Instantiate(BottomBossDoor, BottomSpawn3.transform.position, Quaternion.Euler(0f, 180f, 0f));
                break;
            case 8:
                Instantiate(BottomBossDoor, BottomSpawn4.transform.position, Quaternion.Euler(0f, 180f, 0f));
                break;
        }
    }
    public void SpawnBackDoors()
    {
      
        switch (spawnPos2)
        {
            case 1:
                Instantiate(BackTopDoor, TopSpawn1.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(BackTopDoor, TopSpawn2.transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(BackTopDoor, TopSpawn3.transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(BackTopDoor, TopSpawn4.transform.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(BackBottomDoor, BottomSpawn1.transform.position, Quaternion.Euler(0f, 180f, 0f));
                break;
            case 6:
                Instantiate(BackBottomDoor, BottomSpawn2.transform.position, Quaternion.Euler(0f, 180f, 0f));
                break;
            case 7:
                Instantiate(BackBottomDoor, BottomSpawn3.transform.position, Quaternion.Euler(0f, 180f, 0f));
                break;
            case 8:
                Instantiate(BackBottomDoor, BottomSpawn4.transform.position, Quaternion.Euler(0f, 180f, 0f));
                break;

        }

    }
}
