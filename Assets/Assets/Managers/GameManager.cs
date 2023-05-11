using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timeBeforeShoot = default;
    public Player player;
    [HideInInspector] public bool isCanShoot = default;
    [HideInInspector] public bool isFirstShot = true;
    public static GameManager instanse;
    private float curTimer;

    private void Awake()
    {
        instanse = this;
    }

}
