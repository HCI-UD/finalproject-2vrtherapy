﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnScript : MonoBehaviour
{

    public GameObject fishMenu;
    public GameObject fishButton;
    public GameObject chickenMenu;
    public GameObject chickenButton;
    public GameObject afterMenu1;
    public GameObject afterMenu2;
    public GameObject afterCube1;
    public GameObject afterCube2;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    { 
        fishButton.SetActive(true);
        chickenButton.SetActive(true);
        fishMenu.SetActive(true);
        chickenMenu.SetActive(true);
        afterMenu1.SetActive(false);
        afterMenu2.SetActive(false);
        afterCube1.SetActive(false);
        afterCube2.SetActive(false);
        Debug.Log("RETURN SCRIPT");
        Debug.Log("afters trigger returnscript: " + afterMenu1.activeSelf + " " + afterMenu2.activeSelf + " " + afterCube1.activeSelf + " " + afterCube2.activeSelf);
        Debug.Log("befores trigger returnscript: " + fishMenu.activeSelf + " " + fishButton.activeSelf + " " + chickenButton.activeSelf + " " + chickenMenu.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}