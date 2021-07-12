using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_Door : MonoBehaviour
{

    [SerializeField]
    private string direction;


    //we need to save the direction of the door in the script.
    /*we get the next room from acessing the neighbors dictionary for the desired direction in the current room. 
    After identifying the next room, we change the current room in the dungeon and restart the demo scene.*/
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject dungeon = GameObject.FindGameObjectWithTag("Dungeon");
            SC_DungeonGeneration dungeonGeneration = dungeon.GetComponent<SC_DungeonGeneration>();
            SC_Room room = dungeonGeneration.CurrentRoom();
            dungeonGeneration.MoveToRoom(room.Neighbor(this.direction));
            SceneManager.LoadScene("Demo");
        }
    }
}
