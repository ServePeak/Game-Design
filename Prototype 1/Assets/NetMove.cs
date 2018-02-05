using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetMove : MonoBehaviour {

	private float timerNet;
	private float swapNet = 1f;

	// Use this for initialization
	void Start () {
		timerNet = Random.Range (0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Translate (-Time.deltaTime/2 + Time.deltaTime*swapNet, -Time.deltaTime/3, 0);

		timerNet += Time.deltaTime;
		if (timerNet > 1f) {
			swapNet *= -1;
			timerNet = 0;
		}
	}
}
