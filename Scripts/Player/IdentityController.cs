using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class IdentityController : MonoBehaviour
{

    public Health health;

    // Use this for initialization
    void Awake()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
