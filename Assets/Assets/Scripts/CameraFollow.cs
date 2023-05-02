using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform unit;
    [SerializeField] private float speed = 2;

    private Transform selfTransform;
    private Vector3 newPosition;
    private float distanceToUnit;

    private Vector3 startPosition;
    
    public bool isActiveControl = true;
    
    private void Start()
    {
        selfTransform = transform;
        distanceToUnit = unit.position.z + transform.position.z;
        startPosition = selfTransform.position;
        newPosition = new Vector3(unit.position.x, selfTransform.position.y, selfTransform.position.z);
    }
    
    private void Update()
    {
        //&& !UIManager.instanse.isEnd (Paste this for danceMan)
        if (isActiveControl)
        {
            MovementAxesX();
            MovementAxesY();
        }
    }

    private void MovementAxesX()
    {
        newPosition.x = unit.position.x;

        selfTransform.position =  Vector3.Lerp(selfTransform.position, newPosition, speed * Time.deltaTime);
    }

    private void MovementAxesY()
    {
        if (distanceToUnit != unit.position.z + transform.position.z)
        {
            newPosition.z = unit.position.z-4 + startPosition.z;
            selfTransform.position =  Vector3.Lerp(selfTransform.position, newPosition , speed * Time.deltaTime);
        }
    }

}
