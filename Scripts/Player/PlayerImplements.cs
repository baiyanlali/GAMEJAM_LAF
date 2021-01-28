using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LAF;

interface IMovable
{
    void move(Rigidbody2D rigid, float vec);

}

interface IJumpable
{
    void jump(Rigidbody2D rigid,float vec);
}

interface IAttackable
{
    void attack(float vec);
}


public class Health : MonoBehaviour
{
    public int maxHp=1;

    int currentHp;

    bool isAlive => currentHp > 0;

    public int Increment(int offset)
    {
        currentHp = Mathf.Clamp(currentHp + offset, 0, maxHp);
        return currentHp;
    }
    public int Decrement(int offset)
    {
        currentHp = Mathf.Clamp(currentHp - offset, 0, maxHp);
        if (!isAlive)
        {
            var sc = Simulation.Schedule<Died>();
            //sc.
        }
        return currentHp;
    }



    Health()
    {
        currentHp = maxHp;
    }

}

