using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pour : MonoBehaviour
{
    [SerializeField] private int runTime = 5;
    private float timer = -5;
    public GameObject cap;
    public GameObject milk;
    public Animator anim;
    public Camera camera;
    
    void Start()
    {
        
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name == "milk carton")
            {
                if (Input.GetKeyDown(KeyCode.R) && cap.gameObject.activeSelf == false)
                {
                    timer = runTime;
                    milk.gameObject.SetActive(true);
                    anim.Play("Pour");
                }
                else if (Input.GetKeyDown(KeyCode.R) && cap.gameObject.activeSelf == true)
                {
                    print("no");
                }
            }
        }
        if (timer <= 0 && timer > -5)
        {
            anim.Play("Stop Pour");
            this.enabled = false;
        }
    }

    
}
