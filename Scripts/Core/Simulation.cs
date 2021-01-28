using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Core
{
    public static partial class Simulation
    {
        static HeapQueue<Event>
        static Dictionary<System.Type, Stack<Event>> eventPools = new Dictionary<System.Type, Stack<Event>>();
       
    }


    public static partial class Simulation
    {
        public abstract class Event : System.IComparable<Event>
        {
            internal float tick;

            public int CompareTo(Event other)
            {
                return tick.CompareTo(other.tick);
            }

            public abstract void Execute();

        }
    }

}
