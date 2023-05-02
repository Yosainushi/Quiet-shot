using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = default;
    [SerializeField] private Joystick _joystick;
    private Vector2 lastMousePos;
    private Rigidbody rb;


    private void Awake()
    {
        rb = target.GetComponent<Rigidbody>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_joystick.isTouched)
        {
            MovePlayer();
        }

    }


    private void MovePlayer()
    {
        if (_joystick.Horizontal() != 0 || _joystick.Vertical() != 0)
        {

            Vector3 direction = new Vector3(_joystick.Horizontal(), 0, -_joystick.Vertical());

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            target.transform.LookAt(direction + target.transform.position);
            //rb.AddForce(direction*speed);
            rb.velocity = target.transform.forward * speed;
            // target.Translate(direction*speed * Time.deltaTime,Space.World);
        }
        else
        {
            _joystick.isTouched = false;
            StartCoroutine(StopMoving());
        }
    }

    private IEnumerator StopMoving()
    {
        while (rb.velocity != Vector3.zero)
        {
            rb.velocity -= rb.velocity / 100;
        }

        yield return null;
    }
}

    
