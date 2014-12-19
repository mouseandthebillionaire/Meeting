using UnityEngine;
using System.Collections;

public class TimeScript : MonoBehaviour {

	public float t = 0.0f;
	private float startTime = 0.0f;
	public int sleepLevel = 0;
	public float realTime;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		// Get Guy
		GameObject guy = GameObject.Find ("Guy");
		GuyScript guyScript = guy.GetComponent<GuyScript>();

		t = Time.time - startTime;

		/*
		if (t >= 5.0f && t < 50.0f){
			sleepLevel = 1;
		} else if (t >= 50.0f && t < 100.0f){
			sleepLevel = 2;
		} else if (t >= 100.0f && t < 150.0f){
			sleepLevel = 3;
		} else {
			sleepLevel = 0;
		}
		*/


		KeyControl ();

		if (Input.GetMouseButtonDown(0)) {
			ResetTime();
			sleepLevel = 0;
			int rNum = Random.Range(1, 4);
			guyScript.StopAllCoroutines();
			guyScript.React(rNum);
		}
	}


	public void ResetTime() {
		startTime = Time.time;
	}

	public void KeyControl(){
		if(Input.GetKey("0")){
			sleepLevel = 0;
		} else if (Input.GetKey("1")){
			sleepLevel = 1;
		} else if (Input.GetKey("2")){
			sleepLevel = 2;
		} else if (Input.GetKey("3")){
			sleepLevel = 3;
		} else if (Input.GetKey("4")){
			sleepLevel = 4;
		}
	}
	
}
