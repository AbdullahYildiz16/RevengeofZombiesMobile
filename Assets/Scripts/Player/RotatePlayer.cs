using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public float sensivity = 3;
    Vector2 lookAxis;
    public FixedTouchField TouchField;
    CharacterController fps;
    
    void Update()
    {
        lookAxis = TouchField.TouchDist;
        fps = GetComponent<CharacterController>();
        RotatePlayerBody();
    }

    private float rotateX = 0;
    private float rotateY = 0;
    private void RotatePlayerBody()
    {
        rotateY += sensivity * lookAxis.y * - 1;
        rotateX += sensivity * lookAxis.x;
        rotateY = Mathf.Clamp(rotateY, -80, 80);
    
        transform.eulerAngles = new Vector3(rotateY, rotateX, 0);


    }
}
