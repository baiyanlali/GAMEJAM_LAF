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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos">determine the position of this object(only x will affect)</param>
        /// <param name="isRight">determine the facing of the object</param>
        public void restart(Vector2 pos,bool isRight)
        {
            float p = (pos.x - path.startPos.x) / (path.endPos.x - path.startPos.x);
            float cutTime = p * duration;
            if (isRight) startTime = Time.time - (2 * duration - cutTime);
            else startTime = Time.time - cutTime;
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
