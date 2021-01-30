using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

delegate void jump(Rigidbody2D rigid, float vec);
delegate void move(Rigidbody2D rigid, Vector2 vec);
public class PlayerControl : IdentityController
{
    GameObject eyes;
    public GameObject Eyes
    {
        get 
        {
            return eyes;
        }
        set
        {
            eyes = value;
            if (eyes != null)
            {
                eyes.transform.parent = this.transform;
                eyes.SetActive(false);

            }
        }
    }
    public GameObject eyes_Prefab;
    public Feet feet;
    public Hands hands;
    public AudioSource _audio;

    public bool hasEye=>Eyes;

    Rigidbody2D rigid;
    public Animator anim;
    UnityAction<Rigidbody2D,float> jump;
    UnityAction<Rigidbody2D,float> move;
    UnityAction<float> attack;


    public AudioClip jumping, landing, hurt;
    public AudioClip[] walk;


    // Start is called before the first frame update
    void Start()
    {
        feet = GetComponentInChildren<Feet>();
        hands = GetComponentInChildren<Hands>();

        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();

        jump = feet.jump;
        move = feet.move;
        attack = hands.attack;

        Eyes = Instantiate(eyes_Prefab);

    }

    // Update is called once per frame
    void Update()
    {
        jump(rigid, Input.GetAxis("Jump"));
        move(rigid, Input.GetAxis("Horizontal"));
        attack(Input.GetAxis("Fire1"));
        
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }
}
