using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    float speed = 0.01f;
    float rotationSpeed = 0.1f;
    bool flag = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speed, Space.Self);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -speed, Space.Self);
        }
        
        if (Input.GetKey(KeyCode.D)){
            transform.Rotate(0, rotationSpeed, 0);
        }
        
        if (Input.GetKey(KeyCode.A)){
            transform.Rotate(0, -rotationSpeed, 0);
        }
    }
}
