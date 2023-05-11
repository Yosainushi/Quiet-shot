using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapGunButton : MonoBehaviour
{
    public List<Sprite> _sprites;
    private Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    public void SwapButton()
    {
        if (img.sprite==_sprites[0])
        {
            img.sprite = _sprites[1];
        }
        else
        {
            img.sprite = _sprites[0];
        }
        GlobalEnentManager.SwapWeapon.Invoke();
    }
        
}
