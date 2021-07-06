using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_RoomTemplates : MonoBehaviour
{

    public GameObject[] bottomRooms, topRooms, leftRooms, rightRooms;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedExit;
    public GameObject exit;
    public GameObject alternative;
    public int numSpawns;
    [SerializeField]
    private int spawncount;

    void Update(){
        if(waitTime <=0 && spawnedExit == false){
            for(int i = 0; i< rooms.Count; i++){
                if (i==rooms.Count-1){
                    Instantiate(exit, rooms[i].transform.position, Quaternion.identity);
                    spawnedExit = true;
                }
            }
        } else{
            waitTime -= Time.deltaTime;
        }
    }

    public int GetSpawnCount(){
        return spawncount;
    }

    public void SetSpawnCount(int newSpawnCount){
        spawncount = newSpawnCount;
    }

}
