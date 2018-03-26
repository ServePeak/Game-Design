using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollide : MonoBehaviour {

    public AudioClip sound;
    public GameObject splat;
    public GameObject player;
    private List<GameObject> splatter = new List<GameObject>();
    private GameObject spawned;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "player") {
            audioSource.PlayOneShot(sound, 0.25F);
            spawned = Instantiate(splat, new Vector3(player.transform.position.x, player.transform.position.y, 0f), Quaternion.identity);
            splatter.Add(spawned);
        }
    }
}
