/*

using UnityEngine;
using System.Collections;

public class ColleagueScript : MonoBehaviour {

	public float defaultY;
	public float awareY;
	private int sleepLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		GameObject gameManager = GameObject.Find ("GameManager");
		ControllerScript controllerScript = gameManager.GetComponent<ControllerScript>();	
		sleepLevel = ControllerScript.sleepLevel;

		if (sleepLevel == 3){
			transform.rotation = Quaternion.Slerp(
				transform.rotation, 
				Quaternion.Euler (new Vector3(0, -60f, 0)), 
				.001f);
		} else {
			transform.rotation = Quaternion.Euler(0, defaultY, 0);
		}
	
	}

}

*/
