using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    AudioSource audioSource;
    public float speed;
    private bool play_1;
    private bool play_2;
    private bool play_3;
    private bool play_4;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector2(moveHorizontal, moveVertical);

        rb.velocity = movement * speed;

        if (transform.position.x > 10.0f && transform.position.y > 5.0f && !play_1) {
            audioSource.PlayOneShot(sound1, 0.5F);
            play_1 = true;
        } else if (transform.position.x > 20.0f && transform.position.y > 10.0f && !play_2) {
            audioSource.PlayOneShot(sound2, 0.5F);
            play_2 = true;
        } else if (transform.position.x < -10.0f && transform.position.y < 5.0f && !play_3) {
            audioSource.PlayOneShot(sound3, 0.5F);
            play_3 = true;
        } else if (transform.position.x > 30.0f && transform.position.y > 15.0f && !play_4) {
            audioSource.PlayOneShot(sound4, 0.5F);
            play_4 = true;
        }
    }
}
