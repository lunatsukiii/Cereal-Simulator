using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class CountCereal : MonoBehaviour
{
    private Collider[] hitColliders;
    private int count = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cereal"))
        {
            count++;
            Debug.Log("poop");
            if (count == 100)
            {
                Debug.Log("You have collected all the cereals");
            }
        }
    }

}
