using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    public GameObject objectToPickUp;
    public GameObject PickedObject;
    public Transform interactionZone;

    void Update()
    {
        if (objectToPickUp != null && objectToPickUp.GetComponent<PickableObject>().isPickable == true && PickedObject == null)
        {
            if (Input.GetKey(KeyCode.P))
            {
                objectToPickUp.SetActive(false);

                /*
                PickedObject = objectToPickUp;
                PickedObject.GetComponent<PickableObject>().isPickable = false;
                PickedObject.transform.SetParent(interactionZone);
                PickedObject.transform.position = interactionZone.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
                //PickedObject.SetActive(false);*/
            }
        }
    }



}
