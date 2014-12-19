using UnityEngine;
using System;

public class ClockScript : MonoBehaviour {

	private const float
		hoursToDegrees = 360f / 12f,
		minutesToDegrees = 360f / 60f,
		secondsToDegrees = 360f / 60f;
	
	public Transform hours, minutes;
	
	void Update () {
		DateTime time = DateTime.Now;
		hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
		minutes.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees);
		//seconds.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees);
	}
}