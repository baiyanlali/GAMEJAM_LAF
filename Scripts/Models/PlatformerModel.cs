using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlatformerModel
{
    private PlayerControl _player;
    public PlayerControl player {

        get {
            if (_player == null)
            {
                _player = GameObject.Find("Player").GetComponent<PlayerControl>();
            }
            return _player;
        }
        
    }
    public Transform spawnPoint;
    public CameraController cameraController;
}
