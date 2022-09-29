using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collect : MonoBehaviour
{
    public float maxDiamond = 10f;
    private float pickedUp = 0f;
    public ParticleSystem explode;
    public Text collecting;

    //bool 
    private bool isexplode = false;
    private bool iscollect = false;

    void Update()
    {
        collecting.text = string.Format("{0:0}", pickedUp);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diamond")
        {
            if (pickedUp < maxDiamond)
            {
                //Debug.Log("Collected Diamond");
                pickedUp += 1;
                Destroy(other.gameObject);
                iscollect = true;
            }
        }
        if (other.tag == "Asteroid")
        {
            //Debug.Log("Got in asteroid");
            if (pickedUp != 0)
                pickedUp -= 1;
            Instantiate(explode, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            isexplode = true;
        }      
    }
    public bool checkDiamond()
    {
        //Debug.Log(pickedUp);
        if (pickedUp == 10)
            return true;
        else
            return false;
    }

    /*void OnTriggerExit(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            Debug.Log("left asteroid");
            isexplode = false;
        }      
    }*/

    public bool isExplode()
    {
        if (isexplode)
            return true;
        else
            return false;
    }

    public void setIsExplode(bool isexplode)
    {
        this.isexplode = isexplode;
    }

    public bool isCollect()
    {
        if (iscollect)
            return true;
        else
            return false;
    }
    public void setIsCollect(bool iscollect)
    {
        this.iscollect = iscollect;
    }
}
