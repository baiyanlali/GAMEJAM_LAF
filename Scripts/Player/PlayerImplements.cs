using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMovable
{
    void move(Rigidbody2D rigid, float vec);

}

interface IJumpable
{
    void jump(Rigidbody2D rigid,float vec);
}
