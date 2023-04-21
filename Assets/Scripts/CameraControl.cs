using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Vector3 cameraOffset = new Vector3();
    private float shakeTime = 0.0f;
    private float shakeMagnitude = 0.0f;

    private float StopTime = 0.0f;

    void Start()
    {
        cameraOffset = Vector3.zero; 
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeTime > 0.0f) 
        { 
            shakeTime -= Time.deltaTime;

            cameraOffset.x = Random.Range(-shakeMagnitude, shakeMagnitude);
            cameraOffset.y = Random.Range(-shakeMagnitude, shakeMagnitude);

            transform.position = transform.parent.position - Vector3.forward * 10 + cameraOffset;
        }
        else
        {
            transform.position = transform.parent.position - Vector3.forward * 10;
        }
    }

    public void ShakeCamera(float time, float magnitude) 
    {
        shakeTime = time;
        shakeMagnitude = magnitude;
    }
}
