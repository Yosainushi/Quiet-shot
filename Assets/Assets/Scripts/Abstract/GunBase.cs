using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public abstract class GunBase : MonoBehaviour
{
   // [SerializeField] private int coolDown = default;
    [SerializeField] private int bulletPullCount = default;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletLifeTime;
    public Transform bulletPullParent;
    [SerializeField] private Transform bulletStartPosition;
    
    protected Queue<Bullet> bulletPull;

    
    
    protected void Awake()
    {
        FillBulletPull();
    }

    public void FillBulletPull()
    {
        bulletPull = new Queue<Bullet>();
        
        for (int i = 0; i < bulletPullCount; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab, bulletPullParent);
            bullet.speed = bulletSpeed;
            bullet.parentPool = bulletPull;
            bullet.gameObject.SetActive(false);
            bullet.lifeTime = bulletLifeTime;
            bulletPull.Enqueue(bullet);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Shot(Vector3 point)
    {
        Bullet bullet = bulletPull.Dequeue();
        bullet.transform.position = bulletStartPosition.position;
        bullet.gameObject.SetActive(true);
        bullet.transform.rotation = transform.parent.rotation;
        bullet.Shot(point);
    }
}
