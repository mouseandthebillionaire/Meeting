using UnityEngine;
using System.Collections;

public class GuyScript : MonoBehaviour {

	public GameObject upperArm;
	public GameObject lowerArm;
	public GameObject leftHand;
	public GameObject phoneHand;
	public GameObject mug;
	public GameObject leftEye;
	public GameObject rightEye;
	public GameObject head;

	public Light laptop;

	public float headRoteX = 359.0f;
	public float headRoteY = 0.0f;
	
	public int reactionState = 0;
	
	private int sleepLevel;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		GameObject gameManager = GameObject.Find ("GameManager");
		ControllerScript cs = gameManager.GetComponent<ControllerScript>();

		sleepLevel = cs.sleepLevel;

		switch(sleepLevel){
		case 0:
			// defaults
			leftEye.transform.localScale = new Vector3(.125f, .125f, .1f);
			rightEye.transform.localScale = new Vector3(.125f, .125f, .1f);
			head.transform.position = new Vector3(0f, 0f, -5.5f);
			headRoteX = 0.0f;
			break;

			
		case 1:	// Eyes Closing
			closeEyes ();
			Debug.Log(sleepLevel);
			break;

		case 2:	// Nod Head
			//MoveHead(340.0f);
			Debug.Log(sleepLevel);
			break;

		case 3:
			leftEye.transform.localScale = new Vector3(0, 0, 0);
			rightEye.transform.localScale = new Vector3(0, 0, 0);
			head.transform.rotation = Quaternion.Euler(-45, 0, 0);
			break;

		case 4: // Dream
			StartCoroutine(Dream());
			break;

		default:
			break;
		}

	}
	

	private void closeEyes(){
		if(leftEye.transform.localScale.y >= 0){
			leftEye.transform.localScale -= new Vector3(0, .0001f, 0);
			rightEye.transform.localScale -= new Vector3(0, .0001f, 0);
		}
	}


	public void React(int _r){
		int r = _r;

		if(r == 0){
			head.transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else if(r == 1){
			StartCoroutine(ShakeHead());
		}
		else if(r == 2){
			StartCoroutine(Compute());
		}
		else if(r == 3){
			StartCoroutine(CheckPhone());
		}
	}

	private IEnumerator ShakeHead(){
		head.transform.rotation = Quaternion.Euler(0, 0, 0);
		yield return new WaitForSeconds(1.0f);
		head.transform.rotation = Quaternion.Euler(0, -10, 0);
		yield return new WaitForSeconds(0.5f);
		head.transform.rotation = Quaternion.Euler(0, 10, 0);
		yield return new WaitForSeconds(0.5f);
		head.transform.rotation = Quaternion.Euler(0, -10, 0);
		yield return new WaitForSeconds(0.5f);
		head.transform.rotation = Quaternion.Euler(0, 10, 0);
		yield return new WaitForSeconds(2.0f);
		head.transform.rotation = Quaternion.Euler(0, 0, 0);
		yield break;
	}

	private IEnumerator Compute(){
		head.transform.rotation = Quaternion.Euler(0, 0, 0);
		yield return new WaitForSeconds(1.0f);
		leftHand.transform.position = new Vector3(0.4f, -1.5f, -6.2f);
		head.transform.rotation = Quaternion.Euler(-10, -10, 0);
		yield return new WaitForSeconds(0.5f);
		leftHand.transform.position = new Vector3(0.6f, -1.5f, -6.8f);
		LaptopScript laptopScript = laptop.GetComponent<LaptopScript>();
		StartCoroutine(laptopScript.TurnOn());
		yield return new WaitForSeconds(0.5f);
		leftHand.transform.position = new Vector3(0.4f, -1.5f, -6.2f);
		yield return new WaitForSeconds(0.5f);
		leftHand.transform.position = new Vector3(0, -3.0f, -6.2f);
		yield return new WaitForSeconds(3.0f);
		head.transform.rotation = Quaternion.Euler(0, 0, 0);
		yield break;
	}

	private IEnumerator CheckPhone(){
		head.transform.rotation = Quaternion.Euler(358.0f, 0, 0);
		yield return new WaitForSeconds(1.0f);
		phoneHand.transform.position = new Vector3(0.4f, -1.5f, -6.2f);
		StartCoroutine(MoveHead(new Vector3(330f, -10f, 0), 1f)) ;
		yield return new WaitForSeconds(3f);
		phoneHand.transform.position = new Vector3(0, -3.0f, -6.2f);
		head.transform.rotation = Quaternion.Euler(0, 0, 0);
		yield break;
	}

	private IEnumerator Dream(){
		StartCoroutine(MoveHead(new Vector3(0f, 0f, 0f), 5f));
		var t = 0.0f;
		Vector3 startPos = head.transform.position;
		Vector3 endPos = new Vector3(head.transform.position.x, 20f, head.transform.position.z);
		while (t < 1.0f) {
			t += Time.deltaTime * .005f;
			head.transform.position = Vector3.Lerp(startPos, endPos, t);
			yield return null; 
		}
		yield break;

	}

	IEnumerator MoveHead(Vector3 byAngles, float inTime){
		Quaternion fromAngle = head.transform.rotation ;
		Quaternion toAngle = Quaternion.Euler(head.transform.eulerAngles + byAngles) ;
		for(float t = 0f ; t < 1f ; t += Time.deltaTime/inTime){
			head.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t) ;
			yield return null ;
		}
	}
	

}
