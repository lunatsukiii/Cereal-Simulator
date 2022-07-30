using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class CountCereal : MonoBehaviour
{
    private Collider[] hitColliders;
    public float bowlRadius;


    private void OnCollisionEnter(Collision col)
    {
        CerealinBowl(col.contacts[0].point);
    }

    void CerealinBowl(Vector3 bowlPosition)
    {
        hitColliders = Physics.OverlapSphere(bowlPosition, bowlRadius);
        foreach (Collider hitCol in hitColliders)
        {
            Debug.Log(hitCol.gameObject.name);
            if (hitCol.gameObject.tag == "Cereal")
            {
                
            }
        }
    }
    
}
