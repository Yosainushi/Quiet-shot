using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public List<Image> listGuns;
    public Animation animReloadButtton;
    
    public static UIManager instanse;
    
    private void Awake()
    {
        GlobalEnentManager.Reload.AddListener(ReloadButtonAnim);
        instanse = this;
    }
    public void ReloadButton()
    {
        if (!animReloadButtton.isPlaying)
        {
            GlobalEnentManager.Reload.Invoke();
        }
    }

    public void ReloadButtonAnim()
    {
        animReloadButtton.Play();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
