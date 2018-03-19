using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject bullet;
    public List<GameObject> bullets = new List<GameObject>();
    private GameObject spawned;
    private float time;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (time > 0.25f) {
            Vector2 movement = Vector2.zero;
            bool key = false;
            if (Input.GetKey("left")) {
                movement += Vector2.left;
                key = true;
            } else if (Input.GetKey("right")) {
                movement += Vector2.right;
                key = true;
            }
            if (Input.GetKey("up")) {
                movement += Vector2.up;
                key = true;
            } else if (Input.GetKey("down")) {
                movement += Vector2.down;
                key = true;
            }
            if (key)
                SpawnBullet(movement);
            time = 0;
        }
	}

    void SpawnBullet(Vector2 movement) {
        spawned = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
        spawned.GetComponent<BulletMove>().spawned = true;
        spawned.GetComponent<BulletMove>().speed = 3.0f;
        spawned.GetComponent<BulletMove>().movement = movement;
        bullets.Add(spawned);
        bullets.RemoveAll((o) => o == null);
    }
}
