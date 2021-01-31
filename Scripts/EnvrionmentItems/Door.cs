using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LAF;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl player = collision.GetComponent<PlayerControl>();
        if (player)
        {
            Simulation.Schedule<PlayerWin>();
        }
    }
}
