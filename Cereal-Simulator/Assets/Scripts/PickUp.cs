using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float pickUpRange = 5;
    public float moveForce = 250;
    public Transform holdParent;
    private GameObject heldObj;
    public GameObject check;
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(heldObj == null)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit, pickUpRange))
                {
                    PickupObject (hit.transform.gameObject);
                    
                }
            }
            else
            {
                DropObject();
            }
        }        

        if(heldObj != null)
        {
            MoveObject();
        }
    }

    void MoveObject ()
    {
        if(Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
        {

            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickupObject (GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;

            objRig.transform.parent = holdParent;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldObj.GetComponent<Rigidbody>().useGravity = true;  
        heldRig.drag = 1;      

        heldObj.transform.parent = null;
        heldObj = null;
    }

    
}
