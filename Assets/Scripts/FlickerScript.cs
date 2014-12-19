using UnityEngine;
using System.Collections;

public class FlickerScript : MonoBehaviour {
	
	public float duration = 5.0F;
	public float probability = 0.9f;
	public float amplitude = 0.5f;
	public float flicker = 0.3f;

	void Update() {
		if(Random.value > .95F){
			light.intensity = flicker;
		} else {
			/*
			float phi = Time.time / duration * 2 * Mathf.PI;
			float amplitude = Mathf.Cos(phi) * 0.07F + 0.5F;
			*/ 
			light.intensity = amplitude;


		}
	}

}
