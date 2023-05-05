using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    internal Queue<Bullet> parentPool = default;
    internal float speed = default;
    internal float lifeTime;
    private float currentLifeTime;
    private Coroutine currentCor;
    private Transform thisTransform;

    private void Awake()
    {
        thisTransform = transform;
    }

    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shot(Vector3 direction)
    {
        currentLifeTime = lifeTime;
        currentCor = StartCoroutine(MoveToTarget(direction));
    }

    private IEnumerator MoveToTarget(Vector3 direction)
    {
        while (currentLifeTime>0)
        {
            currentLifeTime -= Time.deltaTime;
            thisTransform.position = Vector3.Lerp(thisTransform.position, thisTransform.position + direction, speed * Time.deltaTime);
            yield return null;
        }
        DisableBullet();
    }

    private void DisableBullet()
    {
        StopCoroutine(currentCor);
        parentPool.Enqueue(this);
        gameObject.SetActive(false);
    }
}
