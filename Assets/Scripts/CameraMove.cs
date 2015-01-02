using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public GameObject	guy;
	public float		camZ;
	public float		easing = .005f;
	public Light		spotlight;
		
	// Update is called once per frame
	void Update () {

		if(guy.transform.position.y > 2.5f){
			Vector3 destination = guy.transform.position;
			destination = Vector3.Lerp(transform.position, destination, easing);
			destination.z = camZ;
			transform.position = destination;
			spotlight.transform.position = destination;
		} else {
			transform.position = new Vector3(0, .5f, -10.0f);
			spotlight.transform.position = new Vector3(0, 0, -15);
		}

	}
}
