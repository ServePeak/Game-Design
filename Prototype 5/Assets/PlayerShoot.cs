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

		if (Input.GetKey("space") && time > 0.25f) {
            SpawnBullet();
            time = 0;
        }
	}

    void SpawnBullet() {
        spawned = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 0.2f, 0f), Quaternion.identity);
        spawned.GetComponent<BulletMove>().spawned = true;
        spawned.GetComponent<BulletMove>().speed = 3.0f;
        spawned.GetComponent<BulletMove>().movement = new Vector2(0.0f,1.0f);
        bullets.Add(spawned);
        bullets.RemoveAll((o) => o == null);
    }
}
