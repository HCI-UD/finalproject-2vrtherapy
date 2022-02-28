using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class showAtSpeed : MonoBehaviour
{
    public GameObject controllerPos;
    public float speedLimit = 0.008f;
    private Vector3 priorPos;

    private Renderer _renderer;
    // Update is called once per frame

    void Start()
    {
        _renderer = this.GetComponent<Renderer>();
    }
    void Update()
    {
        Vector3 currentPos = controllerPos.transform.position;
        float speed = Vector3.Distance(currentPos, priorPos);
//        Debug.Log("At " + Time.time*1000f +". Hand Position:" + controllerPos.transform.position.ToString("F4"));
        
        priorPos = currentPos;

        _renderer.enabled = Math.Abs(speed) > speedLimit;
    }
}
