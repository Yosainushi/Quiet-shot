using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    internal GunBase gun;
    [SerializeField]internal List<GunBase> allGuns = new List<GunBase>();
    private Coroutine corShoot;
    private JoystickShoot _joystickShoot;
    

    private void Awake()
    {
        gun = allGuns[0];
        GlobalEnentManager.Reload.AddListener(ReloadGun);
        GlobalEnentManager.SwapWeapon.AddListener(SwapWeapon);
        _joystickShoot = GetComponent<MoveController>()._joystickShoot;
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        if (GameManager.instanse.isCanShoot&&_joystickShoot.isTouched)
        {
             corShoot??=StartCoroutine(Shoot());
        } 
    }

    private IEnumerator Shoot()
    {
        gun.Shot(transform.forward);
        corShoot = null;
        yield break;
    }

    public void ReloadGun()
    {
        gun.Reload(UIManager.instanse.animReloadButtton.clip.length);
    }

    public void SwapWeapon()
    {
        if (gun==allGuns[0] && allGuns[0]!=null)
        {
            allGuns[1].gameObject.GetComponent<MeshRenderer>().enabled=true;
            gun = allGuns[1];
            allGuns[0].gameObject.GetComponent<MeshRenderer>().enabled=false;
        }
        else
        {
            if (gun==allGuns[1])
            {
                allGuns[0].gameObject.GetComponent<MeshRenderer>().enabled=true;
                gun = allGuns[0];
                allGuns[1].gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
