using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Rigidbody2D rb2d;
    public GameObject inside;
    public GameObject spawner;
    public bool moveable = true;
    public bool spawned = false;
    public bool clickable = false;
    public bool moving = false;
    public bool destroyable = false;
    public bool finished_space = false;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (spawned) { 
            if (Input.GetKeyDown("space") && !finished_space) {
                moveable = false;
                clickable = true;
                gameObject.layer = 9;
            }
            if (moveable) {
                float moveHorizontal = Input.GetAxis("Horizontal");
                float moveVertical = Input.GetAxis("Vertical");
                Vector2 movement = new Vector2(moveHorizontal * 20, moveVertical * 20);
                rb2d.AddForce(movement);
            }
            if (clickable && Input.GetMouseButtonDown(0)) {
                Vector2 distance = (transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)).normalized;
                rb2d.AddForce(-distance*3000);
                clickable = false;
                moving = true;
                finished_space = true;
            }
            if (moving) {
                if (rb2d.velocity.magnitude < 0.01) {
                    destroyable = true;
                    moving = false;
                    spawner.GetComponent<SpawnPlayers>().SpawnPlayer();
                }
            }
            if (destroyable) {
                Collider2D i_Collider = inside.GetComponent<Collider2D>();
                Collider2D m_Collider = GetComponent<Collider2D>();
                bool is_inside = i_Collider.bounds.Contains(m_Collider.bounds.max) && i_Collider.bounds.Contains(m_Collider.bounds.min);

                if (!is_inside) {
                    Destroy(gameObject);
                }
            }
        }
    }
}
