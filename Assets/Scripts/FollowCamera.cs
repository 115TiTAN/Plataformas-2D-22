using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float speed = 10;
    CameraControl camControl = null;
    // Start is called before the first frame update
    void Start()
    {
        camControl = GetComponentInChildren<CameraControl>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        
    }

    public void ShakeCam(float time, float magnitude)
    {
        if (camControl != null)
        {
           camControl.ShakeCamera(time, magnitude);
           
        }
    }
}
