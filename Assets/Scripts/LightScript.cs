﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour {

    public bool IsLit = false;
    private Light light;

	// Use this for initialization
	void Start () {

        light = this.gameObject.GetComponentInChildren<Light>();
        light.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        

	}

    public void toggleLight()
    {
        IsLit = !IsLit;
        light.enabled = IsLit;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            toggleLight();
        }
    }
}
