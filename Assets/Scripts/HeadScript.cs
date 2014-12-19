using UnityEngine;
using System.Collections;

public class HeadScript : MonoBehaviour {

	public GameObject leftEye;
	public GameObject rightEye;
	public float headRoteX = 0.0f;
	public float t = 0.0f;
	//private float eyeSize = 0.125f;
	public int sleepLevel = 0;
	public int trouble = 0;

	// Update is called once per frame
	void Update () {
		GameObject gameManager = GameObject.Find ("GameManager");
		TimeScript timer = gameManager.GetComponent<TimeScript>();
		t = timer.t;

		Debug.Log(sleepLevel);

		if (t >= 5.0f && t < 50.0f){
			sleepLevel = 1;
		} else if (t >= 50.0f && t < 100.0f){
			sleepLevel = 2;
		} else if (t >= 100.0f && t < 150.0f){
			sleepLevel = 3;
		} else {
			sleepLevel = 0;
		}

		switch(sleepLevel){
		case 0:
			// defaults
			leftEye.transform.localScale = new Vector3(.125f, .125f, .1f);
			rightEye.transform.localScale = new Vector3(.125f, .125f, .1f);
			headRoteX = 0.0f;
			break;

		
		case 1:	// Eyes Closing
			leftEye.transform.localScale -= new Vector3(0, .0001f, 0);
			rightEye.transform.localScale -= new Vector3(0, .0001f, 0);

			if(leftEye.transform.localScale.y <= 0.0f){
				sleepLevel = 2;
			}
			trouble++;
			break;

		
		
		case 2:
			leftEye.transform.localScale = new Vector3(0, 0, 0);
			rightEye.transform.localScale = new Vector3(0, 0f, 0);


			headRoteX -= .1f;

			if(this.transform.rotation.y <= -40.0f){
				Debug.Log("Asleep");
				sleepLevel = 3;
			}
			trouble+=2;
			break;

		case 3:
			headRoteX = -40.0f;
			trouble+=3;
			break;

		
		
		default:
			break;
				
		}

		/*
	
		if(Input.GetKey("space")){
			headRoteX -= 0.5F;
			headRoteY -= 0.5F;
		} else {
			headRoteX = 0.0f;
			headRoteY = 0.0f;
		}*/

		//this.transform.rotation = Quaternion.Euler(headRoteX, headRoteY, 0);
	
	}


}
