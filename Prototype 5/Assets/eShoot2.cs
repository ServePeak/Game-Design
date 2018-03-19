using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eShoot2 : MonoBehaviour {

    public AudioClip impact;
    AudioSource audioSource;
    public GameObject bullet;
    public List<GameObject> bullets = new List<GameObject>();
    private GameObject spawned;
    private float time;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

		if (GetComponent<BossHealth>().stage_2 && !GetComponent<BossHealth>().stage_4 && time > 0.5f) {
            SpawnBullet(new Vector3(1.0f, 1.0f, 0.0f));
            SpawnBullet(new Vector3(-1.0f, -1.0f, 0.0f));
            SpawnBullet(new Vector3(0.0f, 0.0f, 0.0f));
            time = 0;
        }
	}

    void SpawnBullet(Vector3 angle) {
        spawned = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
        spawned.GetComponent<eBulletMove>().spawned = true;
        spawned.GetComponent<eBulletMove>().speed = 3.0f;
        Vector2 distance = (GameObject.FindGameObjectWithTag("player").transform.position - spawned.transform.position - angle).normalized;
        Rigidbody2D rb = spawned.GetComponent<Rigidbody2D>();
        rb.velocity = distance * 5;
        bullets.Add(spawned);
        audioSource.PlayOneShot(impact, 0.05F);
        bullets.RemoveAll((o) => o == null);
    }
}
