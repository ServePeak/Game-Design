using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMove : MonoBehaviour {

	private float swapHook = 1f;
	private float timerHook;

	// Use this for initialization
	void Start () {
		timerHook = Random.Range (0.0f, 4.8f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Translate (-Time.deltaTime, Time.deltaTime*swapHook, 0);

		timerHook += Time.deltaTime;
		if (timerHook > 4.8f) {
			swapHook *= -1;
			timerHook = 0;
		}
	}
}
