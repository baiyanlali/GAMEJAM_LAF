using System.Collections;
using UnityEngine;
using LAF;

public class Enemy : IdentityController
{
    
        
    public bool enable = true;
    public float moveSpeed=1f;
    public Rigidbody2D rigid;
    public SpriteRenderer sprite;
    public int enemy_face=1;

    public AudioSource _audio;

    public AudioClip died;


    protected virtual void Start()
    {
        
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        _audio = GetComponent<AudioSource>();
        
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

    public virtual void BeAttacked(int value, Vector2 playerpos)
    {

    }

    
    protected virtual IEnumerator beingAttacked(float time,Vector2 playerpos)
    {
        return null;

    }


}
