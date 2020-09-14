using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    /// <summary>
    /// cam - Main Camera/Gameplay camera
    /// speed - speed the camera moves
    /// </summary>
    public Camera cam;
    public int speed = 10;

    /// <summary>
    /// Simple code to move the camera forward to demonstrate the endless scene
    /// </summary>
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            cam.transform.position += new Vector3(0, 0, 1) * (speed * Time.deltaTime);
        }
    }
}