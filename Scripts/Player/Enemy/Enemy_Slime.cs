using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Slime : Enemy
{

    public enum enemyStatus { patrol, beAttacked }
    public PatrolPath patrolPath;
    public enemyStatus curState;
    PatrolPath.Mover mover;



    void Update()
    {
        if (mover != null && curState == enemyStatus.patrol)
        {
            sprite.flipX = (mover.Position.x - transform.position.x) > 0;
            rigid.MovePosition(mover.Position);
        }

    }

    protected override void Start()
    {
        base.Start();
        if (patrolPath != null)
        {
            mover = new PatrolPath.Mover(patrolPath, moveSpeed);
        }
            curState = enemyStatus.patrol;
    }


    public override void BeAttacked(int value, Vector2 playerpos)
    {
        //print("enemy be attacked");
        health.Decrement(value);
        StartCoroutine(beingAttacked(1f, playerpos));
    }

    protected override IEnumerator beingAttacked(float time, Vector2 playerpos)
    {
        curState = enemyStatus.beAttacked;
        rigid.AddForce(((Vector2)transform.position - playerpos) * 10);
        yield return new WaitForSeconds(time);

        mover?.restart(transform.position, sprite.flipX);// when not flip x, right
        curState = enemyStatus.patrol;


    }



}
