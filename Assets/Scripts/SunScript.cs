using UnityEngine;
using System.Collections;

public class SunScript : MonoBehaviour {
	public int sunX;
	private int timer = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer++;
		if (timer % 200 == 0){
			sunX = 1;
		} else {
			sunX = 0;
		}
		rigidbody.AddForce(sunX, 0, 0);

	
	}
}
