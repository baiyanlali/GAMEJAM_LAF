using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LAF;

public class Enemy : IdentityController
{
    // Start is called before the first frame update
    public PatrolPath patrolPath;
    public float moveSpeed=1f;
    public Rigidbody2D rigid;
    PatrolPath.Mover mover;
    // Update is called once per frame
    void Update()
    {
        if(mover!=null)
            rigid.MovePosition(mover.Position);
    }

    private void Start()
    {
        if (patrolPath != null)
        {
            mover = new PatrolPath.Mover(patrolPath,moveSpeed);
        }
        rigid = GetComponent<Rigidbody2D>();
    }

    public GameObject eyes;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl player = collision.GetComponent<PlayerControl>();
        //print($"Enemy hit player,{player}");
        if (player != null)
        {
            var ev = Simulation.Schedule<EnemyHitPlayer>();
            ev.enemy = this;
        }
    }

    public void bindEyes(GameObject eyes)
    {
        this.eyes = eyes;
        eyes.transform.parent = this.transform;
        eyes.transform.localPosition = Vector2.zero;
        eyes.SetActive(true);

    }

    public override void Die()
    {
        if(eyes)
            eyes.transform.parent = null;
        Destroy(gameObject);
    }
}
