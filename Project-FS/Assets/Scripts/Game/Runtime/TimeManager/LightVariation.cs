using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LightVariation : MonoBehaviour
{
    private Light lightcomponent;
    private float LightIntensity;
    private float time;
    private Vector3 lightDirection = Vector3.zero;
    private TimeDisplay displayTime;
    private float endRotationX = 0;
    // Start is called before the first frame update
    void Start()
    {
        lightDirection = transform.rotation.eulerAngles;
        lightcomponent = GetComponent<Light>();
        time = 0;
        //Debug.Log(lightDirection);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        displayTime = TimeManager.GetInstance().DisplayTime;
        
        if (displayTime.Hour > 6 && displayTime.Hour < 19)
        {
            time = (float)(60 * displayTime.Hour + displayTime.Minute);
        }
        time /= 24 * 60;
        endRotationX = Mathf.Lerp(0,180, time);
        lightDirection.x = endRotationX;
        lightcomponent.intensity = 2*(1 - Mathf.Abs((time - 0.5f) * 2));
        Debug.Log(endRotationX);
        transform.DOLocalRotate(lightDirection,0);
    }
}
