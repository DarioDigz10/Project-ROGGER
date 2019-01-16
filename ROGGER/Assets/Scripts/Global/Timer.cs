using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float slowdownDuration;

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
        if (Time.timeScale != 1f)
        {
            Time.timeScale += (1f / slowdownDuration) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            Time.fixedDeltaTime = Time.timeScale * .02f;
        }

        if (events.Count == 0) return;

        for (int i = 0; i < events.Count; i++)
        {
            TimedEvent timedEvent = events[i];
            if (timedEvent.timeToexecute <= Time.time)
            {
                timedEvent.method();
                events.Remove(timedEvent);
            }
        }
    }

    public void DoBulletTime(float slowdownFactor, float slowdownDuration)
    {
        Mathf.Clamp(slowdownFactor, 0.05f, 1f);
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        this.slowdownDuration = slowdownDuration;
    }

}
