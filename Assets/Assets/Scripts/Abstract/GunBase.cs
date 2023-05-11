using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public abstract class GunBase : MonoBehaviour
{
    
    [SerializeField] private float timeIntervalShots = default;
    [SerializeField] private int maxCountAmmo = default;
    //[SerializeField] private float timeReload = default;
    [SerializeField] private int bulletPullCount = default;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletLifeTime;
    public Transform bulletPullParent;
    [SerializeField] protected Transform bulletStartPosition;
    public int damage = default;
    
    public int ammoCountRemaining;
    protected float curTimerIntervalShots;
    protected Coroutine timerCoroutine;
    protected Coroutine corIntervalShot;
    protected Queue<Bullet> bulletPull;
    protected float timeBeforeShoot = default;
    protected bool isStartShoot;
    
    protected void Awake()
    {
        
        FillBulletPull();
        ammoCountRemaining = maxCountAmmo;
        
       
    }
    private void Start()
    {
        timeBeforeShoot = GameManager.instanse.timeBeforeShoot;
    }
    public void FillBulletPull()
    {
            bulletPull = new Queue<Bullet>();
        
            for (int i = 0; i < bulletPullCount; i++)
            {
                Bullet bullet = Instantiate(bulletPrefab, bulletPullParent);
                bullet.speed = bulletSpeed;
                bullet.gunParent = this;
                bullet.parentPool = bulletPull;
                bullet.gameObject.SetActive(false);
                bullet.lifeTime = bulletLifeTime;
                bulletPull.Enqueue(bullet);
            }
        
    }

    public virtual void Shot(Vector3 point)
    {
        if (!isStartShoot)
        {
            corIntervalShot??=StartCoroutine(TimerIntervalShots());
            isStartShoot = true;
        }
        
        if (ammoCountRemaining>0 )
        {
            if (curTimerIntervalShots<=0)
            {
                Bullet bullet = bulletPull.Dequeue();
                bullet.transform.position = bulletStartPosition.position;
                bullet.gameObject.SetActive(true);
                bullet.transform.rotation = transform.parent.rotation;
                bullet.Shot(point);
                GameManager.instanse.isFirstShot = false;
                ammoCountRemaining--;
                corIntervalShot??=StartCoroutine(TimerIntervalShots());
            }
        }
        if (ammoCountRemaining==0)
        { 
            Debug.Log("Reload");
            GlobalEnentManager.Reload.Invoke();
        }
        
        
    }

    public void Reload(float time)
    {
        timerCoroutine ??= StartCoroutine(ReloadProcess(time));
    }
    public IEnumerator ReloadProcess(float time)
    {
        yield return new WaitForSeconds(time);
        ammoCountRemaining = maxCountAmmo;
        corIntervalShot??=StartCoroutine(TimerIntervalShots());
        timerCoroutine = null;
        
    }
    
    protected IEnumerator TimerIntervalShots()
    {
        if (GameManager.instanse.isFirstShot)
        {
            curTimerIntervalShots = timeBeforeShoot;
        }
        else
        {
            curTimerIntervalShots = timeIntervalShots;
        }
       
        while (curTimerIntervalShots>=0)
        {
            curTimerIntervalShots -= Time.fixedDeltaTime;
            if (curTimerIntervalShots<=0)
            {
                corIntervalShot = null;
            }
            yield return null;
        }
        
        
    }

    public void StopShoot()
    {
        
        if (corIntervalShot!=null)
        {
            StopCoroutine(corIntervalShot);
        }
        corIntervalShot= null;
        isStartShoot = false;
        GameManager.instanse.isFirstShot = true;
    }
}
