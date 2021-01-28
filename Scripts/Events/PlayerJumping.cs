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
