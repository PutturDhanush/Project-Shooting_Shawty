using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float Hspeed = 3.0f;
    public float Vspeed = 3.0f;

    public float mouseX;
    public float mouseY;

    private void Update()
    {
        mouseX += Hspeed * Input.GetAxis("Mouse X");
        mouseY += Vspeed * Input.GetAxis("Mouse Y");

        transform.eulerAngles =new Vector3(-mouseY, mouseX, 0.0f);
    }
}

