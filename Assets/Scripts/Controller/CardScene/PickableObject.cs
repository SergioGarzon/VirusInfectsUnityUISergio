using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public bool isPickable;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerInteraction")
        {
            Destroy(other.gameObject);
            //other.GetComponentInParent<PickUpObject>().objectToPickUp = this.gameObject;
        }
    }


    /*
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "PlayerInteraction")
        {
            other.GetComponentInParent<PickUpObject>().objectToPickUp = null;
        }
    }*/

}
