using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Object;
    [SerializeField] private int _spawnAmount = 350;
    [SerializeField] private int runTime = 5;
    private PickUp pickedUp;
    private float timer = -5;
    public Camera camera;
    public Animator anim;
    private List<GameObject> LoopsQueue = new List<GameObject>();

    private void Start()
    {
        for (var i = 0; i < _spawnAmount; i++)
        {
            var shape = Instantiate(Object);
            shape.SetActive(false);
            LoopsQueue.Add(shape);
        }
    }

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
                InvokeRepeating(nameof(Spawn), 0.05f, 0.005f);
            }
        }
    }
    private void Spawn()
    {
        foreach (var loop in LoopsQueue)
        {
            loop.SetActive(true);
            loop.transform.position = transform.position;
            LoopsQueue.Remove(loop);
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

        if ((GameObject.Find("box").transform.position - GameObject.Find("ObjectHolder").transform.position).magnitude < 0.1f)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartSpawn();
            }
        }

        

    }
}
