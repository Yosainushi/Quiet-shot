using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GunBase gun;
    [SerializeField] private float timeBeforeShoot = default;
    private float curTimer;

    private void Awake()
    {
        curTimer = timeBeforeShoot;
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        if (GameManager.instanse.isCanShoot)
        {
            curTimer -= Time.deltaTime;
            if (curTimer<=0)
            {
                Shoot();
                curTimer = timeBeforeShoot;
            }
        } 
    }

    private void Shoot()
    {
        gun.Shot(transform.forward);
    }
}
