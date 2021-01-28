using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LAF;
using static LAF.Simulation;

public class PlayerJumping : Event<PlayerJumping>
{

    public PlayerControl player;

    public override void Execute()
    {
        
        Debug.Log("jumped");
    }
}


public class Died : Event<Died>
{
    public IdentityController identity;
    public override void Execute()
    {
        if (identity.GetType().Equals(typeof(PlayerControl)))
        {
            //player died

        }
        else
        {
            //enemy died

        }
    }
}
