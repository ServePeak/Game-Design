using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (this.GetComponent<Rigidbody2D>().velocity.x != 0f || this.GetComponent<Rigidbody2D>().velocity.y != 0f) { 
		    if (this.transform.position.x > 12 || this.transform.position.x < -12 ||
                this.transform.position.y > 7 || this.transform.position.y < -6) {
                Destroy(this.gameObject);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "BallCircle" || collision.gameObject.tag == "BallSquare") {
            Destroy(this.gameObject);
        } else if (collision.gameObject.tag == "Player") {
            SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
        }
    }
}
