using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Object;
    [SerializeField] private int _spawnAmount = 100;
    [SerializeField] private int runTime = 5;
    private PickUp pickedUp;
    private float timer = -5;
    public Camera camera;
    public Animator anim;
    
    private void StartSpawn()
    {
        if (!anim.GetBool("Open"))
            return;
        
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name == "box" && anim.GetBool("Open")) 
            {
                anim.Play("BoxPour");
                timer = runTime;
                InvokeRepeating(nameof(Spawn), 0.2f, 0.2f);
            }
        }
    }
    private void Spawn() 
    {
        for (var i = 0; i < _spawnAmount; i++)
        {
            var shape = Instantiate(Object);
            shape.transform.position = gameObject.transform.position;
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && timer > -5)
        {
            anim.Play("Stop BoxPour");
            CancelInvoke();
            this.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartSpawn();
        }

    }
}
