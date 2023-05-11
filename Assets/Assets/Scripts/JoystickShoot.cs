using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickShoot : Joystiks
{
    void Awake()
    {
        bgImg = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        GameManager.instanse.player.gun.StopShoot();
        GameManager.instanse.isCanShoot = false;
    }

    public float VerticalShoot()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxisRaw("HorizontalShoot");
       
    }
    public float HorizontalShoot()
    {
        if (inputVector.y != 0)
            return inputVector.y;
        else
            return Input.GetAxisRaw("VerticalShoot");
    }
    
}
