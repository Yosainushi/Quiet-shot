using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float speed = default;
    [SerializeField] private float rotationSpeed = default;
    [SerializeField] private JoystickMove _joystickMove;
    [SerializeField] private JoystickShoot _joystickShoot;
    private Rigidbody rb;
    private Player pl;


    private void Awake()
    {
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
                    Time.deltaTime * rotationSpeed);
                Debug.Log(directionMove);
                rb.velocity = directionMove * speed;
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionShoot),
                    Time.deltaTime * rotationSpeed);
                GameManager.instanse.isCanShoot = true;
            }

        
            //StartCoroutine(StopMoving());
        
    }

    private IEnumerator StopMoving()
    {
        Debug.Log("stop");
        rb.angularVelocity = new Vector3(0, 0, 0);
        rb.velocity = Vector3.zero;
        /*while (rb.velocity != Vector3.zero)
        {
            rb.velocity -= rb.velocity / 100;
        }*/

        yield return null;
    }
}

    
