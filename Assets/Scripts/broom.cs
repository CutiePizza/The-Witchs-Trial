using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class broom : MonoBehaviour
{
    public bool BroomIsGrabbed = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Broom")
        {
            BroomIsGrabbed = true;
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.tag == "Broom")
        {
            BroomIsGrabbed = false;
        }
    }
}
