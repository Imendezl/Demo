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

    public float waitTime = 4f;

    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<SC_RoomTemplates>();
        Invoke("Spawn", 0.1f);
        
    }

    void Spawn()
    {
        if (spawned == false)
        {           
            switch (openingDirection)
            {
                case 1:
                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                    break;
                case 2:
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                    break;
                case 3:
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                    break;
                case 4:
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                    break;

            }
            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("SpawnPoint")){
            if(other.GetComponent<SC_RoomSpawner>().spawned == false && spawned == false){
                //Instantiate(templates.alternative, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            
            spawned = true;
        }
    }

}
