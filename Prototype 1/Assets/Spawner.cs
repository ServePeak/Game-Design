using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject shark;
	public GameObject hook;
	public GameObject net;

	private List<GameObject> enemies = new List<GameObject>();
	private float timer;
	private float swap = 1f;
	private FishMove fishScript;

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindWithTag ("Player");
		fishScript = player.GetComponent<FishMove> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		for (int i = enemies.Count-1; i >= 0; i--) {
			if (enemies[i].tag == "Shark" && enemies[i].transform.position.x >= 35) {
				Destroy (enemies[i]);
				enemies.Remove(enemies[i]);
			}

			if (enemies[i].tag == "Hook" && enemies[i].transform.position.x <= 1) {
				Destroy (enemies[i]);
				enemies.Remove(enemies[i]);
			}
			if (enemies[i].tag == "Net" && (enemies[i].transform.position.x <= -15 || enemies[i].transform.position.y <= -6)) {
				Destroy (enemies[i]);
				enemies.Remove(enemies[i]);
			}
		}

		timer += Time.deltaTime;
		if (timer > 1f) {
			swap *= -1;
			timer = 0;

			for (int i = -1; i < fishScript.score / 10; i++) {
				int rand = Random.Range (0, 11);
				if (rand == 0) {
					enemies.Add (Instantiate (shark, new Vector3 (-15, Random.Range (-21f, -8.6f), 0), Quaternion.identity));
				}
				rand = Random.Range (0, 11);
				if (rand == 0) {
					enemies.Add (Instantiate (hook, new Vector3 (Random.Range (28f, 33f), -5, 0), Quaternion.identity));
				}
				rand = Random.Range (0, 11);
				if (rand == 0) {
					enemies.Add (Instantiate (net, new Vector3 (Random.Range (15f, -10f), 5.5f, 0), Quaternion.identity));
				}
			}
		}
	}
}
