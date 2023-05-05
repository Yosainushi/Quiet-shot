using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class JoystickMove : Joystiks
{
    
    private void Start()
    {
        bgImg = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public float Vertical()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else return Input.GetAxisRaw("Vertical");
            
       
    }
    public float Horizontal()
    {
        if (inputVector.y != 0)
            return inputVector.y;
        else
            return Input.GetAxisRaw("Horizontal");
            
    }
}
