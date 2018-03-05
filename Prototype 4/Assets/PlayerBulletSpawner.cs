using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSpawner : MonoBehaviour {

    public GameObject bullet;
    public GameObject player;
    public List<GameObject> bullets = new List<GameObject>();
    private GameObject spawned;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            SpawnBullet();
        }
    }

    void SpawnBullet() {
        spawned = Instantiate(bullet, new Vector3(player.transform.position.x,  player.transform.position.y, 0f), Quaternion.identity);
        spawned.GetComponent<BulletMove>().spawned = true;
        var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f);
        position = Camera.main.ScreenToWorldPoint(position);
        spawned.transform.LookAt(position);
        spawned.GetComponent<Rigidbody2D>().velocity = spawned.transform.forward * 1000;
        bullets.Add(spawned);
        bullets.RemoveAll((o) => o == null);
    }
}
