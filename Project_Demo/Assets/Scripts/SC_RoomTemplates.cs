using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_RoomTemplates : MonoBehaviour
{

    public GameObject[] bottomRooms, topRooms, leftRooms, rightRooms;

    public List<GameObject> rooms;

    public float waitTime;
    public bool spawnedExit = false;
    public GameObject exit;
    public GameObject alternative;
    public int numSpawns;
    [SerializeField]
    private int spawncount;

    private List<Transform> newRoomPosition = new List<Transform>();

    void Update()
    {
        if (waitTime <= 0 && spawnedExit == false)
        {

            for (int i = rooms.Count - 1; i >= 0; i--)
            {

                if (rooms[i] != null && spawnedExit == false)
                {
                    //Instantiate(exit, rooms[i].transform.position, Quaternion.identity);
                    spawnedExit = true;
                    SC_Events.event_RoomCheck();

                    /*if (spawnedExit)
                    {
                        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

                        for (int a = 0; a <= spawnPoints.Length - 1; a++)
                        {
                            if (!spawnPoints[a].GetComponent<Collider2D>().IsTouchingLayers())
                            {
                                Debug.Log(spawnPoints[a].transform.root.name);
                                newRoomPosition.Add(spawnPoints[a].transform.root.transform);
                                Destroy(spawnPoints[a].transform.root.gameObject);

                            }else{
                                if ()
                            }
                        }

                    }*/

                }
            }
        }
        else
        {
            if (waitTime >= 0)
            {
                waitTime -= Time.deltaTime;
            }

        }


    }
    public int GetSpawnCount()
    {
        return spawncount;
    }

    public void SetSpawnCount(int newSpawnCount)
    {
        spawncount = newSpawnCount;
    }

}
