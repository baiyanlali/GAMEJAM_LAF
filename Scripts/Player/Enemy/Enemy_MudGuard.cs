using System.Collections;
using UnityEngine;


public class Enemy_MudGuard : Enemy
{

    public Animator anim;

    public float listenZone;

    public Transform feetPos;

    public PlayerControl player;

    public float checkRadius;

    public LayerMask ground;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        feetPos = gameObject.transform.Find("FeetPos");

        ground = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector2 playerPos;
    float disHorizontal;



    void move()
    {
        if (player == null) return;
        playerPos = player.transform.position;
        disHorizontal = Mathf.Abs(playerPos.x - transform.position.x);


    }


    protected bool isGround()
    {
        bool isGround = Physics2D.OverlapCircle(feetPos.position, checkRadius, ground);
        if (anim != null)
        {
            anim.SetBool("isGround", isGround);
        }
        return isGround;
    }

}
