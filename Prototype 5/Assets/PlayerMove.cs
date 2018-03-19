using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector2(moveHorizontal, moveVertical);

        rb.velocity = movement * 3.0f;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "ebullet") {
            //health -= 1;
            Destroy(col.gameObject);

        }
    }
}
