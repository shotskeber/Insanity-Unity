﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour {
	private int dayLength;   //in minutes
	private int dayStart;
	private int nightStart;   //also in minutes
	public int currentTime;
	public float cycleSpeed;
	private bool isDay;
	private Vector3 sunPosition;
	public Light sun;
	public GameObject earth;
	public Light nightLight;
	private GameObject playerTorch;


	void Start() {
		dayLength = 1440;
		dayStart = 300;
		nightStart = 950;
		currentTime = 700;
		StartCoroutine( TimeOfDay ());
		earth = gameObject;
		sun.intensity = 1f;
		nightLight.intensity = 0f;
		isDay = true;
		playerTorch = GameObject.Find ("Spotlight");

        if (GameManager.instance.currentTime != currentTime)
        {
            currentTime = GameManager.instance.currentTime;
            sun.intensity = GameManager.instance.lightGeneralInt;
            nightLight.intensity = GameManager.instance.lightNightInt;
			isDay = GameManager.instance.isDayGM;

			if (isDay) {
				sun.intensity = 1f;
				nightLight.intensity = 0f;
			} else {
				sun.intensity = 0f;
				nightLight.intensity = 0.375f;
			}
        }
    }

	void Update() {
		GameManager.instance.currentTime = currentTime;
        GameManager.instance.lightGeneralInt = sun.intensity;
        GameManager.instance.lightNightInt = nightLight.intensity;
		GameManager.instance.isDayGM = isDay;
        if (playerTorch) {
			if (isDay) {
				playerTorch.SetActive (false);
			} else {
				playerTorch.SetActive (true);
			}
		}
		if (currentTime > 0 && currentTime < dayStart) {
			isDay =false;
		} else if (currentTime >= dayStart && currentTime < nightStart) {
			if (!isDay) {
				isDay = true;
				StartCoroutine (ScaleX1(sun.intensity, 1f, 10f, sun));
				StartCoroutine (ScaleX1(nightLight.intensity, 0f, 7f, nightLight));
			}
		} else if (currentTime >= nightStart && currentTime < dayLength) {
			if (isDay) {
				isDay = false;
				StartCoroutine (ScaleX1(sun.intensity, 0f, 10f, sun));
				StartCoroutine (ScaleX1(nightLight.intensity, 0.375f, 7f, nightLight));
			}
		} else if (currentTime >= dayLength) {
			currentTime = 0;
		}
		float currentTimeF = currentTime;
		float dayLengthF = dayLength;
		earth.transform.eulerAngles =  new Vector3 (0, 0, (-(currentTimeF / dayLengthF) * 360)+90);
	}

	IEnumerator TimeOfDay(){
		while (true) {
			currentTime += 1;
			int hours = Mathf.RoundToInt( currentTime / 60);
			int minutes = currentTime % 60;
			yield return new WaitForSeconds(1F/cycleSpeed);
		}
	}

	IEnumerator ScaleX1(float start, float end, float time, Light light)
	{
		float lastTime = Time.realtimeSinceStartup;
		float timer = 0.0f;

		while (timer < time)
		{
			light.intensity = Mathf.Lerp(start, end, timer / time);
			timer += (Time.realtimeSinceStartup - lastTime);
			lastTime = Time.realtimeSinceStartup;
			yield return null;
		}
		light.intensity = end;
	}


}
