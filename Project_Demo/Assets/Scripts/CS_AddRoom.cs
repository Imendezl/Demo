using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_AddRoom : MonoBehaviour
{

    private SC_RoomTemplates templates;

    void Start(){
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<SC_RoomTemplates>();
        templates.rooms.Add(this.gameObject);
    }
}
