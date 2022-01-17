using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetCamera;
    public float smoothSpeed = 3f;
    public Vector3 cameraOffset, minValue, maxValue;

    void FixedUpdate(){
        //respawn camera fix
        if (targetCamera == null) {
            targetCamera = GameObject.FindWithTag("Player").transform;
        }
        Vector3 desiredPos = targetCamera.position + cameraOffset;
        Vector3 boundPos = new Vector3(
            Mathf.Clamp(desiredPos.x, minValue.x, maxValue.x),
            Mathf.Clamp(desiredPos.y, minValue.y, maxValue.y),
            Mathf.Clamp(desiredPos.z, minValue.z, maxValue.z)
        );
        Vector3 smoothedPos = Vector3.Lerp(transform.position, boundPos, smoothSpeed);

        transform.position = smoothedPos;
        transform.LookAt(targetCamera);
    }
    void LateUpdate()
    {
        // camera rotate lock
        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);  
    }
}
