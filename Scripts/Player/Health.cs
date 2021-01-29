using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LAF;

public class Health : MonoBehaviour
{
    public int maxHp = 1;

    [SerializeField]
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
            var ev = Simulation.Schedule<Died>();
            ev.identity = GetComponent<IdentityController>();
        }
        return currentHp;
    }

    private void Awake()
    {
        currentHp = maxHp;
    }


}

