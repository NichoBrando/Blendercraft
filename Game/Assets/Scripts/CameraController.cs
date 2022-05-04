using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform cameraPointer;

    [Range(0, 360)]
    public float rotationX;

    void LateUpdate() 
    {
        transform.position = cameraPointer.position;
        transform.eulerAngles = new Vector3(
            rotationX,
            cameraPointer.eulerAngles.y,
            cameraPointer.eulerAngles.z
        );
    }
}
