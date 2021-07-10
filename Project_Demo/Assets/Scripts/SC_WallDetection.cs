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

            Destroy(transform.root.gameObject);


        }
    }

}




