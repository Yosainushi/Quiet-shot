using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = default;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Bullet")
        {
            health -= other.GetComponent<Bullet>().gunParent.damage;
            if (health<=0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        StopAllCoroutines();
        Destroy(this.gameObject);
        
    }
}
