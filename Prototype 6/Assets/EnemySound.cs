using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour {

    public float audioDistance;
    public GameObject player;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
        audioSource.spatialBlend = Vector3.Distance(player.transform.position, transform.position) / audioDistance;
        audioSource.volume = -Mathf.Log(audioSource.spatialBlend, 10);
        if (audioSource.spatialBlend >= 1)
            audioSource.mute = true;
        else
            audioSource.mute = false;
    }
}
