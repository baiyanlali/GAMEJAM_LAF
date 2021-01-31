using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy
{
    public int Hp;
    public char type;
    public bool trig;
    public int state;
    //0:idle 1:move 2:hurt 3:die 4-9: attack 10+:others;
    public void dieJudge()
    {
        if (Hp <= 0)
        {

        }
    }
}

