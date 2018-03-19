using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eShoot2Init : MonoBehaviour {

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
		if (!GetComponent<BossHealth>().stage_2_init && GetComponent<BossHealth>().stage_2) {
            time += Time.deltaTime;

            if (time > 1.0f) {
                for (int i = 0; i < 36; i++) {
                    SpawnBullet();
                    rotation += 10f;
                }
                GetComponent<BossHealth>().stage_2_init = true;
            }
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
