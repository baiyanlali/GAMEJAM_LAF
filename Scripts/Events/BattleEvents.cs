using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LAF;
using static LAF.Simulation;



public class BladeHitEnemy : Event<BladeHitEnemy>
{
    public PlayerControl player = GameController.Instance.model.player;
    public Enemy enemy;
    public override void Execute()
    {
        //Debug.Log($"Blade hit enemy {enemy.name},causing {1} damage");
        enemy.health.Decrement(1);
    }
}

public class EnemyHitPlayer : Event<EnemyHitPlayer>
{
    public PlayerControl player = GameController.Instance.model.player;
    public Enemy enemy;
    public override void Execute()
    {
        if (player.hasEye)
        {
            GameController.Instance.model.cameraController.switchMode(CameraController.cameraMode.withoutEye);
            enemy.bindEyes(player.Eyes);
            player.Eyes = null;
        }
        else
        {
            //TODO
        }
    }
}
