using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LAF;

public class Blade : MonoBehaviour
{
    public enum bladeStatus
    {
        idle,start_to_blade,blading,blade_end
    }

    public bladeStatus curBladeStatus;


    Collider2D collider2d;

    public Animator anim;

    Bounds bounds => collider2d.bounds;

    public LayerMask enemyLayer;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemyLayer = LayerMask.GetMask("Enemy");
        curBladeStatus = bladeStatus.idle;
        collider2d = GetComponent<Collider2D>();
    }


    public void switchStatus(int status)
    {
        updateStatus(status);
    }

    void updateStatus(int status)
    {
        switch (curBladeStatus)
        {
            case bladeStatus.idle:
                if (status == 1) curBladeStatus = bladeStatus.start_to_blade;
                break;
            case bladeStatus.start_to_blade:
                anim.SetBool("StartBlade", false);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(bounds.center, bounds.size,0,enemyLayer);
                foreach (var enemy in colliders)
                {
                    print(enemy.name);
                    Enemy en = enemy.GetComponent<Enemy>();
                    if (en != null)
                    {
                        var sc = Simulation.Schedule<BladeHitEnemy>();
                        sc.enemy = en;

                    }
                }
                if (status == 0) curBladeStatus = bladeStatus.idle;
                else curBladeStatus = bladeStatus.blading;
                break;

            case bladeStatus.blading:
                if (status == 0) curBladeStatus = bladeStatus.idle;
                break;

            case bladeStatus.blade_end:
                //anim.SetBool("StartBlade", false);
                curBladeStatus = bladeStatus.idle;
                break;
        }
        print(curBladeStatus);
    }



}
