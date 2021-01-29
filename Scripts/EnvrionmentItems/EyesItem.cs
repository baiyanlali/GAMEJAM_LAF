using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LAF;

public class EyesItem : MonoBehaviour
{
    public bool isDropped => transform.parent == null;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDropped)
        {
            var ev = Simulation.Schedule<PlayerPickEyes>();
            ev.eyes = this.gameObject;
        }
    }

}
