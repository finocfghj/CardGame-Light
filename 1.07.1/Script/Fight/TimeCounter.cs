using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ʵ��ʱ����ʱͣ�ȹ��ܣ�ֻ��Ҫ����timespeed���ܸı���յ�˥���ٶȺ���Ϸʱ������٣����ڻ�û��

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
