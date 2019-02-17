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
    public static bool block;

    public RotationAxis axes = RotationAxis.MouseX;

    public const float Y_MIN = -80.0f;
    public const float Y_MAX = 75.0f;

    public float Sensitivity_x;
    public float Sensitivity_y;

    public float _rotationX = 0;


    void Update()
    {
        if (!block)
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
        else
        {
            if (axes == RotationAxis.MouseY)
            {
                transform.localEulerAngles = new Vector3(15, 0, 0);
            }
        }
    }

    public void Block(bool state)
    {
        block = state;
    }
}
