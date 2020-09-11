using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Camera cam;
    public int speed = 10;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            cam.transform.position += new Vector3(0, 0, 1) * (speed * Time.deltaTime);
        }
    }
}
