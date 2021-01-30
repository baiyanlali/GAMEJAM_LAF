using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    public Vector2 startPos, endPos;
    // Start is called before the first frame update
    

    public class Mover
    {
        PatrolPath path;
        float p = 0;
        float duration;
        float startTime;

        public Mover(PatrolPath path,float speed = 1f)
        {
            this.path = path;
            this.duration = (path.endPos - path.startPos).magnitude / speed;
            this.startTime = Time.time;
        }

        public Vector2 Position
        {
            get
            {
                p = Mathf.InverseLerp(0, duration, Mathf.PingPong(Time.time - startTime, duration));
                return path.transform.TransformPoint(Vector2.Lerp(path.startPos, path.endPos, p));
            }
        }

    }


}
