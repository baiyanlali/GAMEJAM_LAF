using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour
{
    private enemy bbarrel;
    public GameObject player;
    public GameObject att1, att2;
    //HP speed
    public int hp;
    private int speed;
    //动画 动画状态
    private Animator ani;
    private AnimatorStateInfo animatorInfo;
    //hori
    private float hori;
    //posi
    private Vector3 posi;
    //att2 ava
    private bool doAtt2;
    private bool notAtt;
    private bool isGround;
    private Rigidbody2D rigi;
    private bool alive;
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        bbarrel = new enemy();
        bbarrel.Hp = 9;
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float diff = player.transform.position.x - transform.position.x;
        // Debug.Log(diff);
        if (alive)
        {
            if (diff < 3 && diff > 0)
            {
                att();
                transform.localScale = new Vector3(1, 1, 1);
            }
            if (diff < 0 && diff > -3)
            {
                att();
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
    private void att()
    {
        ani.SetTrigger("att");
    }
    void hurt(int dmg)
    {
        ani.SetTrigger("die");
        alive = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.name == "attzone")
        {
            Debug.LogError("hit barrel");
            hurt(11);
        }
    }
}
