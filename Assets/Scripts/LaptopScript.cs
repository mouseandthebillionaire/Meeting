using UnityEngine;
using System.Collections;

public class LaptopScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	}

	public IEnumerator TurnOn(){
		light.intensity = 1.94f;
		yield return new WaitForSeconds(5.0f);
		light.intensity = 0;
		yield break;
	}
}
