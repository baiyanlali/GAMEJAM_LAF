using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LAF;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public PlatformerModel model = Simulation.GetModel<PlatformerModel>();

    private void OnEnable()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        if (Instance == this) Instance = null;
    }

    private void Update()
    {
        if (Instance == this) Simulation.Tick();
    }

}
