using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float speed = default;
    [SerializeField] private float rotationMoveSpeed = default;
    [SerializeField] private float rotationShootSpeed = default;
    [SerializeField] private JoystickMove _joystickMove;
    [SerializeField] internal JoystickShoot _joystickShoot;
    private Rigidbody rb;
    private Player pl;

    public static MoveController instanse;

    private void Awake()
    {
        instanse ??= this;
        rb = GetComponent<Rigidbody>();
        pl = GetComponent<Player>();
    }
    void Update()
    {
        if (_joystickMove.isTouched ||_joystickShoot.isTouched)
        {
            MovePlayer();
        }

    }
    
    private void MovePlayer()
    {
        
            Vector3 directionMove = new Vector3(_joystickMove.Vertical(), 0, _joystickMove.Horizontal());
            Vector3 directionShoot = new Vector3(_joystickShoot.VerticalShoot(), 0, _joystickShoot.HorizontalShoot());
            if (!_joystickShoot.isTouched)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionMove),
                    Time.deltaTime * rotationMoveSpeed);
               
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionShoot),
                    Time.deltaTime * rotationShootSpeed);
                DrawAimLine(directionShoot);
                GameManager.instanse.isCanShoot = true;
            }
            rb.velocity = directionMove * speed;
    }

    private void DrawAimLine(Vector3 direction)
    {
        
    }
    public void StopMove()
    {
        rb.angularVelocity = new Vector3(0, 0, 0);
        rb.velocity = Vector3.zero;
    }
    
}

    
