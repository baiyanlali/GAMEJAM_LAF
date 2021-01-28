using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

delegate void jump(Rigidbody2D rigid, float vec);
delegate void move(Rigidbody2D rigid, Vector2 vec);
public class PlayerControl : MonoBehaviour
{
    public Eyes eyes;
    public Feet feet;

    Rigidbody2D rigid;
    public Animator anim;
    UnityAction<Rigidbody2D,float> jump;
    UnityAction<Rigidbody2D,float> move;
    


    // Start is called before the first frame update
    void Start()
    {
        feet = this.gameObject.GetComponentInChildren<Feet>();
        rigid = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        jump = feet.jump;
        move = feet.move;
    }

    // Update is called once per frame
    void Update()
    {
        jump(rigid, Input.GetAxis("Jump"));
        move(rigid, Input.GetAxis("Horizontal"));
        
    }
}
