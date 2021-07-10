using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_Door : MonoBehaviour
{

    [SerializeField]
    private string direction;

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
