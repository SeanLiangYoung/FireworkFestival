﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Note : MonoBehaviour {


    int type;

	public float startTime;

	public float duration;

	public List<Note> notes;

	private float noteScale = 5.0f;

	private float scaleInterval = .01f;

	public Launcher launcher;

	public bool deleteMe;

	public ParticleSystem.Particle particle;
	private ParticleSystem.Particle _compareParticle;
    

	Vector3 velocity;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		duration = 2.0f;
		velocity = new Vector3( 0.13f, 0.0f, 0.0f );
		gameObject.transform.localScale = new Vector3(noteScale, noteScale, noteScale);
		//particle = new ParticleSystem.Particle();
		//_compareParticle = particle;
	}

	void FixedUpdate()
	{
        float elpasedTime = Time.deltaTime;
		//gameObject.transform.Translate( velocity );
		Vector3 tempScale = gameObject.transform.localScale;
		tempScale.x -= scaleInterval;
		tempScale.y -= scaleInterval;
		tempScale.z -= scaleInterval;
		gameObject.transform.localScale = tempScale;
		scaleInterval +=.001f;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Die()
	{
		if (notes!=null) {
			//notes.Remove(this);
		}
		Destroy( gameObject );
	}

	public void Disappear(bool andDie) {
		if (this!= null) {
			this.renderer.enabled = false;
			if (andDie) {
				this.deleteMe = true;
				//launcher.DeleteFirework();
			}
		}
	}

    public int Type
    {
        get { return type; }
        set { type = value;  }
    }

	public float GetHitDiff (float time) {
		return Mathf.Abs(startTime+duration-time);
	}

	public float GetElapsedTime (float time) {
		return time - startTime;
	}
}
