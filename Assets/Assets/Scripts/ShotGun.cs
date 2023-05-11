using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : GunBase
{
    public float scatter=default;
    public override void Shot(Vector3 point)
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
                
                List<Bullet> bullets = new List<Bullet>(6);
                for (int i = 0; i < bullets.Capacity; i++)
                {
                    Bullet bullet = bulletPull.Dequeue();
                    bullets.Add(bullet);
                }
                foreach (var bul in bullets)
                {
                    bul.transform.position = bulletStartPosition.position;
                    bul.gameObject.SetActive(true);
                    Vector3 Angle = point;
                    Angle.x += Random.Range(-scatter, scatter);
                    Angle.z += Random.Range(-scatter, scatter);
                    bul.transform.rotation = Quaternion.LookRotation(Angle);
                    bul.Shot(Angle);
                }
                
                GameManager.instanse.isFirstShot = false;
                ammoCountRemaining--;
                corIntervalShot??=StartCoroutine(TimerIntervalShots());
            }
        }
        if (ammoCountRemaining==0)
        { 
            GlobalEnentManager.Reload.Invoke();
        }
    }
}
