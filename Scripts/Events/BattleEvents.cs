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
        enemy.health.Decrement(1);
    }
}
