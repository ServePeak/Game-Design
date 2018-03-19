using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eShoot3 : MonoBehaviour {

    public GameObject bullet;
    public List<GameObject> bullets = new List<GameObject>();
    private GameObject spawned;
    private float time;
    private float rotation;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (GetComponent<BossHealth>().stage_3 && time > 2.0f) {
            for (int i = 0; i < 36; i++) {
                SpawnBullet();
                rotation += 10f;
            }
            time = 0;
            rotation += 5f;
        }
	}

    void SpawnBullet() {
        spawned = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0,0, rotation));
        spawned.GetComponent<eBulletMove>().spawned = true;
        spawned.GetComponent<eBulletMove>().speed = 3.0f;
        bullets.Add(spawned);
        bullets.RemoveAll((o) => o == null);
    }
}
