using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public Transform head;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject scriptou;

    private bool isFlying = false;
    private float HandRight = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
    private float HandLeft = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
    // Update is called once per frame
    void Update()
    {
        HandRight = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        HandLeft = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        float HandRight1 = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
        float HandLeft1 = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
        if ((HandLeft > 0.9 && HandRight > 0.9))
        {
            isFlying = true;
        }
        else
        {
            isFlying = false;
        }

        if (isFlying)
        {
        
        Vector3 leftDir = leftHand.transform.position - head.position;
        Vector3 rightDir = rightHand.transform.position - head.position;

        Vector3 dir = leftDir + rightDir * Time.deltaTime;

        transform.position -= dir * 0.5f;
        }
        else
        {
            Debug.Log("M not flying");
        }
    }
}
