using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    
    private LineRenderer _lineRenderer;
    public Transform endPos;
    public Transform startPos;
    private Vector3 direction;
    public float _lineMax = 5;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (GameManager.instanse.isCanShoot)
        {
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(0,startPos.position);
            float lineLength = Mathf.Clamp(Vector3.Distance(startPos.position, endPos.position), 0, _lineMax);
            _lineRenderer.SetPosition(1,endPos.position);
        }
    }
}
