using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

delegate void jump(Rigidbody2D rigid, float vec);
delegate void move(Rigidbody2D rigid, Vector2 vec);
public class PlayerControl : IdentityController
{
    public Eyes eyes;
    public Feet feet;
    public Hands hands;

    Rigidbody2D rigid;
    public Animator anim;
    UnityAction<Rigidbody2D,float> jump;
    UnityAction<Rigidbody2D,float> move;
    UnityAction<float> attack;
    


    // Start is called before the first frame update
    void Start()
    {
        feet = GetComponentInChildren<Feet>();
        hands = GetComponentInChildren<Hands>();
        eyes = GetComponentInChildren<Eyes>();

        rigid = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        jump = feet.jump;
        move = feet.move;
        attack = hands.attack;
    }

    // Update is called once per frame
    void Update()
    {
        jump(rigid, Input.GetAxis("Jump"));
        move(rigid, Input.GetAxis("Horizontal"));
        attack(Input.GetAxis("Fire1"));
        
    }
}
