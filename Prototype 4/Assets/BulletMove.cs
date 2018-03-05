using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    public bool spawned;
    public float timer = 0;
    public Vector3 mousePos;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (spawned)
            transform.position = Vector3.MoveTowards(transform.position, mousePos, 1.0f);

        if (this.transform.position.x > 12 || this.transform.position.x < -12 || this.transform.position.y > 7 || this.transform.position.y < -6) {
            Destroy(this.gameObject);
        }
    }
}
