using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightController : MonoBehaviour
{
    private Light2D Light;
    private float decreaseSpeed;
    private float decreaseTime;
    private bool isDecreasing;
    private float radius;

    private void Start()
    {
    }

    public void Init(float speed, float time, float r, float itensity)
    {
        Light = GetComponent<Light2D>();
        decreaseSpeed = speed;
        decreaseTime = time;
        radius = r;
        Light.pointLightOuterRadius = radius;
        Light.intensity = itensity;
        StartCoroutine(LightDecrease());
    }

    IEnumerator LightDecrease()
    {
        yield return new WaitForSeconds(decreaseTime);
        isDecreasing = true;
    }

    private void Update()
    {
        if (isDecreasing)
        {
            Light.intensity = TimeCounter.Instance.TimeDecrease(Light.intensity,decreaseSpeed);
        }
        if (Light.intensity < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
