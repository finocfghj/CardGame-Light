using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用于实现时缓，时停等功能

public class TimeCounter : MonoBehaviour
{
    public static TimeCounter Instance;

    public float timeSpeed;

    private void Awake()
    {
        Instance = this;
        timeSpeed = 1;
    }

    public float TimeDecrease(float time)
    {
        return time-=timeSpeed*Time.deltaTime;
    }
}
