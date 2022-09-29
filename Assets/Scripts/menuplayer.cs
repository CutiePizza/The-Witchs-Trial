using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuplayer : MonoBehaviour
{
    public LineRenderer line;
    public ParticleSystem magic;
    public float gravity = -9.81f;
    //public GameObject wandSphere;
    //public float range = 0.1f;
    //public LayerMask WandLayerMask;

    private bool isGrabbed = false;
    private bool pressed = false;
    //store input from right hand trigger
    private float HandRight = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);

    void Start()
    {
        /*Vector3[] startLinePositions = new Vector3[2] { Vector3.zero, Vector3.zero} ;
        line.SetPositions(startLinePositions);*/
        line.enabled = false;
    }

    void Update()
    {
        //Get input from right hand trigger
        HandRight = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
        //Check if it is pressed
        if (HandRight > 0.9)
        {
            //Debug.Log("I got pressed");
            pressed = true;
        }
        else
            pressed = false;
        //If wand taken
        if (isGrabbed == true && pressed == true)
        {
            line.enabled = true;
            if (!magic.isPlaying)
                magic.Play();
        }
        else
        {
            line.enabled = false;
            if (magic.isPlaying)
                magic.Stop();
        }

    }
    // Cast my own Ray
    /*void Ray()
    {
        RaycastHit hit;
        Vector3 forw = Vector3.Normalize(new Vector3(wandSphere.transform.forward.x, wandSphere.transform.position.y, wandSphere.transform.forward.z));
        Ray lineOut = new Ray(wandSphere.transform.position, forw);
        Vector3 endPos = wandSphere.transform.position + (wandSphere.transform.forward * range);

        if (Physics.Raycast(lineOut, out hit, WandLayerMask))
        {
            Debug.Log(hit.transform.name);
            endPos = hit.point;
            
        }
        line.SetPosition(0, wandSphere.transform.position);
        line.SetPosition(1, endPos);

    }*/
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wand11")
        {
            //Debug.Log("Taken");
            isGrabbed = true;
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wand11")
        {
            //Debug.Log("Dropped");
            isGrabbed = false;
        }
    }


}
