using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public GameObject[] inside;

	void Start() {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
		bool inside_obj = false;
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
        this.transform.position = new Vector2(this.transform.position.x + moveHorizontal, this.transform.position.y + moveVertical);
//		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
//		rb2d.AddForce (movement);
//		Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
//		Debug.Log (mousePosition);
//		rb2d.MovePosition(mousePosition);

		foreach (GameObject obj in inside) {
			if (this.transform.position.x < obj.transform.position.x + 0.75 & this.transform.position.x > obj.transform.position.x - 0.75 &
				this.transform.position.y < obj.transform.position.y + 0.75 & this.transform.position.y > obj.transform.position.y - 0.75) {
				inside_obj = true;
				break;
			}
		}
		if (inside_obj == false) {
			Application.LoadLevel (0);  
		}
	}
}
