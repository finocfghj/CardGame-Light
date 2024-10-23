using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用于实现时缓，时停等功能，只需要设置timespeed就能改变光照的衰减速度和游戏时间的流速，现在还没用

public class TimeCounter : MonoBehaviour
{
    public static TimeCounter Instance;

    public float timeSpeed;

    private void Awake()
    {
        Instance = this;
        timeSpeed = 1;
    }

    public float TimeDecrease(float time,float speed=1)
    {
        return time-=timeSpeed*Time.deltaTime*speed;
    }
}
