using UnityEngine;
using System.Collections;

public class Lights : MonoBehaviour {

	public float t = 0.0f;
	public Light spot;
	public Light sun;
	public GameObject meetingLight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject gameManager = GameObject.Find ("GameManager");
		TimeScript timer = gameManager.GetComponent<TimeScript>();
		float sleepLevel = timer.sleepLevel;
		t = timer.t;

		if(sleepLevel >= 3){
			if(spot.spotAngle > 35f){
				spot.spotAngle -= Time.deltaTime;
			} 
			sun.intensity -= Time.deltaTime/5f;
		} else {
			spot.spotAngle = 120f;
			sun.intensity = 5f;
		}

		if(sleepLevel >= 4){
			meetingLight.light.intensity -= Time.deltaTime;
		}




	
	}
}
