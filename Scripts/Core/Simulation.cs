﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace LAF
{
    public static partial class Simulation
    {
        static HeapQueue<Event> eventQueue = new HeapQueue<Event>();
        static Dictionary<System.Type, Stack<Event>> eventPools = new Dictionary<System.Type, Stack<Event>>();

        static public T New<T>() where T : Event, new()
        {
            Stack<Event> pool;
            if(!eventPools.TryGetValue(typeof(T),out pool))
            {
                pool = new Stack<Event>(4);
                pool.Push(new T());
                eventPools[typeof(T)] = pool;
            }

            if (pool.Count > 0)
                return (T)pool.Pop();
            else
                return new T();

        }


        public static void Clear() => eventQueue.Clear();

        static public T Schedule<T>(float tick=0) where T : Event, new()
        {
            var ev = New<T>();
            ev.tick = Time.time + tick;
            eventQueue.Push(ev);
            return ev;
        }

        static public T Reschedule<T>(T ev,float tick) where T : Event, new()
        {
            ev.tick = Time.time + tick;
            eventQueue.Push(ev);
            return ev;
        }

        /// <summary>
        /// return the simulation model instance for a class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>simulation model</returns>
        static public T GetModel<T>() where T: class, new()
        {
            return InstanceRegister<T>.instance;
        }

        static public void SetModel<T>(T instance)where T : class, new()
        {
            InstanceRegister<T>.instance = instance;
        }

        static public void DestroyModel<T>() where T : class, new()
        {
            InstanceRegister<T>.instance = null;
        }

        static public int Tick()
        {
            var time = Time.time;
            var executedEventCount = 0;
            while(eventQueue.Count>0 && eventQueue.Peek().tick <= time)
            {
                var ev = eventQueue.Pop();
                var tick = ev.tick;
                ev.ExecuteEvent();
                if (ev.tick > tick)
                {
                    //event was rescheduled, so do not return it to the pool? But I don't understand
                }
                else
                {
                    ev.Cleanup();
                    try
                    {
                        eventPools[ev.GetType()].Push(ev);
                    }
                    catch (KeyNotFoundException)
                    {
                        //never happen?
                    }
                }
                executedEventCount++;
            }
            return eventQueue.Count;
        }
       
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

            public virtual bool Precondition() => true;

            internal virtual void ExecuteEvent()
            {
                if (Precondition())
                    Execute();
            }

            internal virtual void Cleanup()
            {

            }

        }


        public abstract class Event<T>:Event where T : Event<T>
        {
            public static System.Action<T> OnExecute;

            internal override void ExecuteEvent()
            {
                if (Precondition())
                {
                    Execute();
                    OnExecute?.Invoke((T)this);
                }
            }

        }


        static class InstanceRegister<T> where T:class, new()
        {
            public static T instance = new T();
        }

    }

}
