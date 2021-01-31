using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainScript : MonoBehaviour
{
    private Animator ani;
    private AnimatorStateInfo animatorInfo;
    public GameObject attzone;
    private float ylock;
    // Start is called before the first frame update
    void Start()
    {
        ylock = transform.position.y;
        ani = GetComponent<Animator>();
        animatorInfo = ani.GetCurrentAnimatorStateInfo(0);
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        if (hori != 0)
        {
            transform.localScale = new Vector3(hori>0?1:-1, 1, 1);
            transform.Translate(Vector2.right * hori * 5 * Time.deltaTime);
            ani.SetBool("run", true);
        }
        else
        {
            ani.SetBool("run", false);
        }
        if ((animatorInfo.normalizedTime > 1.0f) && (animatorInfo.IsName("shift")))//normalizedTime: 范围0 -- 1,  0是动作开始，1是动作结束
        {
            transform.position = new Vector3(transform.position.x, -0.24f);
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.position =new Vector3(transform.position.x,1.26f) ;
            ani.SetTrigger("shift");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ani.SetTrigger("att");
            attzone.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            attzone.SetActive(false);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.name == "ground")
        {
            transform.position = new Vector3(transform.position.x,ylock);
            ylock = transform.position.y;
        }
    }

}
