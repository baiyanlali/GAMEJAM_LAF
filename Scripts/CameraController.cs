using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum cameraMode
    {
        withEye,withoutEye
    }
    public cameraMode curCameraMode;
    // Start is called before the first frame update
    void Start()
    {
        curCameraMode = cameraMode.withEye;
        switchMode(curCameraMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchMode(cameraMode moo)
    {
        if (moo == cameraMode.withEye)
        {
            Camera.main.cullingMask = LayerMask.GetMask("Default","TransparentFX","Ignore Raycast","Water","UI","Ground");
        }else if (moo == cameraMode.withoutEye)
        {
            Camera.main.cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Enemy");
        }
        curCameraMode = moo;
    }
}
