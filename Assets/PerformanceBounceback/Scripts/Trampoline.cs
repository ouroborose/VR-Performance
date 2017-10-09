﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {

    public ParticleSystem pSystem;
    public GameManager scoreScript;
    
    

	// Use this for initialization
	void Start () {
		scoreScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        pSystem = GetComponentInChildren<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter(Collision col)
    {
        //Score Point
        scoreScript.score++;
        //Particle effect
        pSystem.Play();
    }
}
