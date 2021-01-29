using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LAF;

public class Feet : MonoBehaviour,IMovable,IJumpable
{

    public bool enable;
    protected enum status
    {
        ground,start_to_jump,jumping,in_flight,landed
    }

    protected bool can_jump;
    protected bool stop_jump;

    [SerializeField]
    protected status jumpState;
    [SerializeField]
    protected status lastJumpState;

    public float speed = 3.0f;
    public float jumpHeight = 2.0f;

    protected float move_vec;
    protected int player_face;//determine if player is facing left or right
    protected float jump_vec;

    protected float jump_time_counter;
    public float jumpTime = 0.1f;

    protected Rigidbody2D rd;


    public Transform feetPos;
    public float checkRadius=0.05f;
    public LayerMask ground;

    public Animator anim;


   


    public void jump(Rigidbody2D rigid, float vec)
    {
        rd = rigid;
        jump_vec = vec;
        //if (jump_vec != 0) jumpState = status.start_to_jump;

        updateJump(vec);
    }

    protected virtual void updateJump(float vec)
    {
        can_jump = false;
        lastJumpState = jumpState;
        switch (jumpState)
        {
            case status.start_to_jump:
                jump_time_counter = 0;
                jumpState = status.jumping;
                can_jump = true;
                if (rd) rd.velocity = Vector2.up * jumpHeight;
                break;
            case status.jumping:

                if (vec != 0)
                {
                    jump_time_counter += Time.deltaTime;
                    if (jump_time_counter < jumpTime)
                    {
                        rd.velocity = Vector2.up * jumpHeight;
                        return;
                    }
                }
                else
                {
                    if (!isGround())
                    {
                        jumpState = status.in_flight;
                    }
                    else
                    {
                        jumpState = status.landed;
                    }
                }
                

                break;
            case status.in_flight:
                if (isGround())
                {
                    jumpState = status.landed;
                }
                break;
            case status.landed:
                if(vec==0)
                    jumpState = status.ground;
                break;

            case status.ground:
                if (vec != 0) jumpState = status.start_to_jump;
                if (!isGround()) jumpState = status.in_flight;
                break;
        }
        //if(lastJumpState!=jumpState)
        //    print(jumpState);
    }

    protected bool isGround()
    {
        bool isGround = Physics2D.OverlapCircle(feetPos.position, checkRadius, ground);
        if (anim != null)
        {
            anim.SetBool("isGround", isGround);
        }
        return isGround ;
    }


    public void move(Rigidbody2D rigid, float vec)
    {
        
        rd = rigid;
        move_vec =vec;
        if (anim != null)
        {
            anim.SetFloat("VelocityX",Mathf.Abs( rigid.velocity.x));
            anim.SetFloat("VelocityY",rigid.velocity.y);

        }
    }


    protected void FixedUpdate()
    {
        if (rd != null)
        {
            rd.velocity = new Vector2( move_vec * speed, rd.velocity.y );
            if (move_vec * player_face < 0)
            {
                player_face = -player_face;
                if(rd!=null)
                    rd.gameObject.transform.localScale = new Vector3(-rd.gameObject.transform.localScale.x,
                                                                     rd.gameObject.transform.localScale.y,
                                                                     rd.gameObject.transform.localScale.z);
            }
        }
    }


    protected void Start()
    {
        if (isGround())
        {
            jumpState = status.ground;
        }
        else
        {
            jumpState = status.in_flight;
        }
        feetPos = transform.Find("FeetPos");
        player_face = 1;
        ground = LayerMask.GetMask("Ground");
        anim = GetComponentInChildren<Animator>();
    }

}

