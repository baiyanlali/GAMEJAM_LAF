using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudGuard : MonoBehaviour
{
    //待定
    public enemy mudGuard;
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
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        doAtt2 = (Random.value>0.9?true:false);
        notAtt = true;
        att1.SetActive(false);
        att2.SetActive(false);
        speed = 1;
        ani = gameObject.GetComponent<Animator>();
        mudGuard = new enemy
        {
            Hp = hp
        };
    }

    // Update is called once per frame
    void Update()
    {
        animatorInfo = ani.GetCurrentAnimatorStateInfo(0);
        posi = transform.position;
        if (animatorInfo.IsName("att"))
        {
            //Debug.LogError("att2");
            att2.SetActive(true);
        }
        if (animatorInfo.IsName("att1"))
        {
            att1.SetActive(true);
        }
        else
        {
            if (animatorInfo.IsName("idle"))
            {
                //Debug.LogError("over");
                att1.SetActive(false);
                att2.SetActive(false);
                notAtt = true;
            }
            
        }
        if (transform.localScale.x == 1) { posi.x -= 1.52f; }
        else { posi.x += 1.52f; }
        if (notAtt)
        {
            moveMent(player);
        }
        
    }
    void moveMent(GameObject player)
    {
        
        Vector3 playerPosi = player.transform.position;
        hori = playerPosi.x - posi.x>0? playerPosi.x - posi.x: posi.x-playerPosi.x;
        if (hori< 3.35 && hori>1.6&&isGround)
        {
            att2M();
        }
        if (hori < 1.34&&isGround)
        {
            att1M();
        }
        hori = playerPosi.x - posi.x > 0 ? 1 : -1;
        if (hori!=0&&notAtt)
        {         
            if((hori>0&&transform.localScale.x<0)||(hori < 0 && transform.localScale.x > 0))
            {
                if (transform.localScale.x == 1)
                { posi.x -= 1.52f; }
                else
                { posi.x += 1.52f; }//relative magnitude
                transform.position = posi;
                transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
            }
            transform.Translate(Vector2.right * hori * speed * Time.deltaTime);
            ani.SetBool("run", true);
        }
        else
        {
            ani.SetBool("run", false);
        }
    }
    public void att1M()
    {
        notAtt = false;
        att1.SetActive(true);
        ani.SetTrigger("att1");
    }
    public void att2M()
    {
        notAtt = false;
        att2.SetActive(true);
        ani.SetTrigger("att2");
        Debug.Log("call att2M");
    }
    void hurt(int dmg)
    {
        ani.Play("hurt", 0, 0);
        mudGuard.Hp -= dmg;
        if (mudGuard.Hp <= 0)
        {
            ani.SetBool("die", true);
        }

    }
    void jump()
    {
        rigi.AddForce(Vector3.up*300);
        isGround = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "wall")
        {
            Debug.LogError("jump");
            jump();
        }
        if(collision.collider.tag == "ground")
        {
            isGround = true;
        }
        if (collision.collider.name == "attzone")
        {
            hurt(11);
        }
    }

}
