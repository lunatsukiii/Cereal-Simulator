using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{

    [SerializeField] private Image crosshair;

    private void Start()
    {
        crosshair.color = new Color(1, 1, 1, 0.75f);
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 50f))
        {
            if (hit.transform.gameObject.CompareTag("Object"))
            {
                crosshair.color = new Color(1, 0, 0, 0.75f);
            }
        }
        else
        {
            crosshair.color = new Color(1, 1, 1, 0.75f);
        }
    }
}
