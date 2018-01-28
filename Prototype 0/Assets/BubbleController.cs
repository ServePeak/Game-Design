using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour {

	private Rigidbody2D rb2d;


	// Use this for initialization
	void Start () {
		float moveHorizontal = Random.Range(1.02f,2.02f);
		float moveVertical = Random.Range(1.02f,2.02f);


		if (Random.Range (0.0f, 1.0f) > 0.5f) {
			moveHorizontal = -moveHorizontal;
		}
		if (Random.Range (0.0f, 1.0f) > 0.5f) {
			moveVertical = -moveVertical;
		}

		Vector2 movement = new Vector2(moveHorizontal, moveVertical);
		rb2d = GetComponent<Rigidbody2D> ();

		rb2d.AddForce (movement, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}
}
