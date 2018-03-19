using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eShoot1 : MonoBehaviour {

    public AudioClip impact;
    AudioSource audioSource;
    public GameObject bullet;
    public List<GameObject> bullets = new List<GameObject>();
    private GameObject spawned;
    private float time;
    private float rotation;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

		if (GetComponent<BossHealth>().stage_1 && !GetComponent<BossHealth>().stage_4 && time > 0.05f) {
            SpawnBullet();
            time = 0;
            rotation += 10f;
        }
	}

    void SpawnBullet() {
        spawned = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0,0, rotation));
        spawned.GetComponent<eBulletMove>().spawned = true;
        spawned.GetComponent<eBulletMove>().speed = 3.0f;
        bullets.Add(spawned);
        bullets.RemoveAll((o) => o == null);
        audioSource.PlayOneShot(impact, 0.05F);
    }
}
