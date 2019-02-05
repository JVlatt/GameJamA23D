using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis axes = RotationAxis.MouseX;

    public const float Y_MIN = -60.0f;
    public const float Y_MAX = 60.0f;

    public float Sensitivity_x = 10.0f;
    public float Sensitivity_y = 10.0f;

    public float _rotationX = 0;

    
    void Update()
    {
        if (axes == RotationAxis.MouseX)
            transform.Rotate(0, Input.GetAxis("Mouse X") * Sensitivity_y, 0);
        else if (axes == RotationAxis.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * Sensitivity_y;
            _rotationX = Mathf.Clamp(_rotationX, Y_MIN, Y_MAX);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        
    }
}
