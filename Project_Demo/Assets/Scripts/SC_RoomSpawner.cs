using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_RoomSpawner : MonoBehaviour
{

    public int openingDirection;
    //1 -- Need bottom door
    //2 -- Need top door
    //3 -- Need left door
    //4 -- Need right door

    private SC_RoomTemplates templates;
    private int rand;
    private bool spawned = false;
    public bool destroyerDetected = false;




    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<SC_RoomTemplates>();
        Invoke("Spawn", 0.1f);
        SC_Events.event_RoomCheck += CheckRooms;



    }

    void Spawn()
    {

        if (spawned == false)
        {


            switch (openingDirection)
            {
                case 1:
                    if (templates.GetSpawnCount() < templates.numSpawns)
                    {
                        rand = Random.Range(0, templates.topRooms.Length);
                        Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);


                        templates.SetSpawnCount(templates.GetSpawnCount() + 1);


                    }

                    break;
                case 2:
                    if (templates.GetSpawnCount() < templates.numSpawns)
                    {
                        rand = Random.Range(0, templates.bottomRooms.Length);
                        Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);


                        templates.SetSpawnCount(templates.GetSpawnCount() + 1);

                    }
                    break;
                case 3:
                    if (templates.GetSpawnCount() < templates.numSpawns)
                    {
                        rand = Random.Range(0, templates.rightRooms.Length);
                        Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);


                        templates.SetSpawnCount(templates.GetSpawnCount() + 1);

                    }
                    break;
                case 4:
                    if (templates.GetSpawnCount() < templates.numSpawns)
                    {
                        rand = Random.Range(0, templates.leftRooms.Length);
                        Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);


                        templates.SetSpawnCount(templates.GetSpawnCount() + 1);

                    }
                    break;

            }


            spawned = true;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            spawned = true;
        }
        else if (other.CompareTag("Destroyer"))
        {
            destroyerDetected = true;
        }

    }

    void CheckRooms()
    {
        if (destroyerDetected == false)
        {
            Debug.Log("entrado");
            Destroy(transform.root.gameObject);
        }
    }







}
