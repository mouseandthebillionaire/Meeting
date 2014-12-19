using UnityEngine;
using System.Collections;

public class SkyScript : MonoBehaviour {

	public GameObject head;
	private float b;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//b = head.transform.position.y / 20.0f;
		//Debug.Log(b);
		renderer.material.color = new Color(0, 0, 0);
	}
}
