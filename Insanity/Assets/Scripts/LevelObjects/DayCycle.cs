using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour {

	public float amplitude = 2.0f;
	public float frequency = 0.5f;
	private float _frequency;
	private float phase = 0.0f;

	public float timeCycle = 1200;
	public Light DirLight;
	public Transform dirTransform;
	public Transform dirTransformNight;

	private float currentTick = 0;
	private float sinTime = 0;

	// Use this for initialization
	void Start () {
		_frequency = frequency;  
	}
	
	// Update is called once per frame
	void Update () {
		if (frequency != _frequency) 
			CalcNewFreq();
		Vector3 v3 = dirTransform.position;
		v3.x = Mathf.Sin (Time.time * _frequency + phase) * amplitude;
		dirTransform.position = v3;

		//UpdateTick ();
		//UpdateSun ();
	}

	void UpdateSun(){
		var percentage = currentTick / timeCycle;
		//dirTransform.Rotate (-1*Vector3.right, 15f * Time.deltaTime); //360 1  1200 
		//dirTransformNight.Rotate (-1*Vector3.up, 15f * Time.deltaTime);
	}

	void UpdateTick(){
		currentTick += Time.deltaTime;
		if (currentTick > timeCycle) {
			currentTick = 0;
		}
	}

	void CalcNewFreq() {
		float curr = (Time.time * _frequency + phase) % (2.0f * Mathf.PI);
		float next = (Time.time * frequency) % (2.0f * Mathf.PI);
		phase = curr - next;
		_frequency = frequency;
	}
}
