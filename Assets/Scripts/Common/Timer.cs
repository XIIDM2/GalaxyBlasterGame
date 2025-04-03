using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public bool IsTimerFinished;

    private float timer;

    public Timer(float timer)
    {
        this.timer = timer;
        IsTimerFinished = false;
    }

    public void Tick(float deltaTime)
    {
        if (IsTimerFinished) return;

        timer -= deltaTime;

        if (timer <= 0)
        {
            timer = 0;

            IsTimerFinished = true;
        }
    }

    public void Reset(float resetTime)
    {

        timer = resetTime;
        IsTimerFinished = false;
    }
}
