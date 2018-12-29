using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private class TimedEvent
    {
        public float timeToexecute;
        public Callback method;
    }
    private List<TimedEvent> events;
    public delegate void Callback();

    private void Awake()
    {
        events = new List<TimedEvent>();
    }

    public void Add(Callback method, float inSeconds)
    {
        events.Add(new TimedEvent
        {
            method = method,
            timeToexecute = Time.time + inSeconds
        });
    }

    public void Update()
    {
        if (events.Count == 0) return;

        for(int i = 0; i < events.Count; i++)
        {
            TimedEvent timedEvent = events[i];
            if(timedEvent.timeToexecute <= Time.time)
            {
                timedEvent.method();
                events.Remove(timedEvent);
            }
        }
    }

}
