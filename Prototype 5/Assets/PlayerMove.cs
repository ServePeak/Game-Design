using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Renderer rend;
    private Rigidbody2D rb;
    private bool hit;
    private float time;
    private int blinked;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector2(moveHorizontal, moveVertical);

        rb.velocity = movement * 3.0f;

        if (blinked == 0) {
            hit = false;
        }

        if (hit) {
            time += Time.deltaTime;

            if (time > 0.1f) {
                rend.enabled = !rend.enabled;
                blinked -= 1;
                time = 0;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "ebullet") {
            //health -= 1;
            Destroy(col.gameObject);
            hit = true;
            blinked = 10;
        }
    }
}
