using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer{
    float duration = 0.0f;
    float accum = 0.0f;
    bool running = false;

    public Timer(float duration)
    {
        this.duration = duration;
    }

    public void Reset(float duration)
    {
        this.duration = duration;
        Reset();
    }

    public void Reset()
    {
        accum = 0.0f;
        running = false;
    }

    public void Start()
    {
        running = true;
    }

    public void Pause()
    {
        running = false;
    }

    public bool IsRunning
    {
        get { return running; }
    }

    public bool Update(float dt)
    {
        if (running)
        {
            accum += dt;
            if (accum >= duration)
            {
                Reset(duration);
                return true;
            }
        }

        return false;
    }

}
