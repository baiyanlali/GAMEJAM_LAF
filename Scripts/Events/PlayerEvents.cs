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
        else if(identity.GetType().Equals(typeof(Enemy)))
        {
            //enemy died
            identity.Die();
            //Debug.Log($"Enemy {identity.name} died");
        }
    }
}

public class PlayerPickEyes : Event<PlayerPickEyes>
{
    public GameObject eyes;
    public PlayerControl player = GameController.Instance.model.player;
    public override void Execute()
    {
        GameController.Instance.model.cameraController.switchMode(CameraController.cameraMode.withEye);
        player.Eyes = eyes;
        
    }
}


