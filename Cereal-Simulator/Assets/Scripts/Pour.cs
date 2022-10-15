using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pour : MonoBehaviour
{
    [SerializeField] private int runTime = 5;
    private float timer = -5;
    public GameObject cap;
    public GameObject milk;
    public GameObject bowlMilk;
    public Animator anim;
    public Animator animit;
    public Camera camera;
    private bool isPoured;

    void Start()
    {
        
        anim = GetComponent<Animator>();
        isPoured = false;

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
                if ((GameObject.Find("milk carton").transform.position -
                     GameObject.Find("ObjectHolder").transform.position).magnitude < 0.1f)
                {
                    if (Vector3.Distance(GameObject.Find("milk carton").transform.position,
                            GameObject.Find("Bowl").transform.position) < 3.5f)
                    {
                        if (Input.GetKeyDown(KeyCode.R) && cap.gameObject.activeSelf == false)
                        {
                            timer = runTime;
                            milk.gameObject.SetActive(true);
                            anim.Play("Pour");
                            bowlMilk.gameObject.SetActive(true);
                            animit.Play("Fill");
                            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                            {
                                print("meow");
                                GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
                                isPoured = true;
                                AchievementManager.instance.NewAchievementSolved("test");
                            }

                            
                        }
                        else if (Input.GetKeyDown(KeyCode.R) && cap.gameObject.activeSelf == true)
                        {
                            print("no");
                        }
                    }
                }

            }
        }

        if (timer <= 0 && timer > -5)
        {
            anim.Play("Stop Pour");
            GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
            this.enabled = false;
        }
    }

    
}
