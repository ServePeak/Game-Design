using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    public Vector2 movement;
    public float speed;
    private Rigidbody2D rb;
    public bool spawned;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (spawned) {
            rb.velocity = movement * speed;

            if (this.transform.position.x > 12 || this.transform.position.x < -12 || this.transform.position.y > 7 || this.transform.position.y < -6) {
                Destroy(this.gameObject);
            }


        }
    }

    /*void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "einit" && spawned) {
            //health -= 1;
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }*/
}
