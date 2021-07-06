using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SC_WallDetection : MonoBehaviour
{



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("wall"))
        {
            Debug.Log("Eliminado");
            Destroy(transform.root.gameObject);
            //WallSensor.wallSensor_event(gameObject.transform.root.GetInstanceID());

        }
    }

}


public static class WallSensor {
    public static Action<int> wallSensor_event;
}