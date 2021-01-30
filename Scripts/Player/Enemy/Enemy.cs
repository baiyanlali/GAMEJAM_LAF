using System.Collections;
using UnityEngine;
using LAF;

public class Enemy : IdentityController
{
    public enum enemyStatus { patrol,beAttacked }
        ;
    public bool enable = true;
    // Start is called before the first frame update
    public PatrolPath patrolPath;
    public float moveSpeed=1f;
    public Rigidbody2D rigid;
    public SpriteRenderer sprite;
    PatrolPath.Mover mover;
    public int enemy_face=1;

    public AudioSource _audio;

    public AudioClip died;

    public enemyStatus curState;

    // Update is called once per frame
    void Update()
    {
        if (mover != null && curState==enemyStatus.patrol)
        {
            sprite.flipX = (mover.Position.x- transform.position.x)>0;
            rigid.MovePosition(mover.Position);
        }
        
    }

    private void Start()
    {
        if (patrolPath != null)
        {
            mover = new PatrolPath.Mover(patrolPath,moveSpeed);
        }
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        _audio = GetComponent<AudioSource>();
        curState = enemyStatus.patrol;
    }

    public GameObject eyes;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enable) return;
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
        _audio.PlayOneShot(died);
        if (eyes)
        {
            eyes.transform.parent = null;

        }
        enable = false;
        Destroy(gameObject,0.5f);
    }

    public override void BeAttacked(int value)
    {
        health.Decrement(value);
    }

    public void BeAttacked(int value,Vector2 playerpos)
    {
        //print("enemy be attacked");
        health.Decrement(value);
        StartCoroutine(beingAttacked(1f,playerpos));
    }

    
    IEnumerator beingAttacked(float time,Vector2 playerpos)
    {
        curState = enemyStatus.beAttacked;
        rigid.AddForce(((Vector2)transform.position - playerpos) * 10);
        yield return new WaitForSeconds(time);

        mover.restart(transform.position, sprite.flipX);// when not flip x, right
        curState = enemyStatus.patrol;


    }


}
