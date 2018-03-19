using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eBulletMove : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
    public bool spawned;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

        //if (spawned)
            //rb.position = this.transform.position + transform.right * 0.5f;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (spawned) {
            if (rb.velocity == new Vector2(0.0f,0.0f))
                rb.velocity = transform.right * speed;

            if (this.transform.position.x > 12 || this.transform.position.x < -12 || this.transform.position.y > 7 || this.transform.position.y < -6) {
                Destroy(this.gameObject);
            }


        }
    }
}
