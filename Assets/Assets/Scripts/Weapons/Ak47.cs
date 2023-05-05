using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47 : GunBase
{
    private bool cooldown;
    private float accuracy = 3f; // on 100 metres
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator ShotCor(Vector3 point)
    {
        float distance = Vector3.Distance(transform.position, point);
        float currentAccuracy = accuracy*(distance / 100);
        base.Shot(point);
        yield return new WaitForSeconds(.05f);
        base.Shot(new Vector3(point.x, point.y+ currentAccuracy, point.z));
        yield return new WaitForSeconds(.05f);
        base.Shot(new Vector3(point.x, point.y+ currentAccuracy*2, point.z));
        cooldown = false;
    }
}
