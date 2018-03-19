using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {

    public AudioClip impact;
    public AudioClip hit;
    public AudioClip death;
    AudioSource audioSource;
    public int health = 100;
    public GameObject camerad;
    public bool stage_1;
    public bool stage_2;
    public bool stage_3;
    public bool stage_4;
    public bool stage_2_init;
    private bool stage_3_init;
    SpriteRenderer m_SpriteRenderer;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (stage_4) {
            float targetScale = 0f;
            float shrinkSpeed = 0.5f;
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(targetScale, targetScale, targetScale), Time.deltaTime * shrinkSpeed);
        }

        if (stage_3)
            m_SpriteRenderer.color = Color.Lerp(m_SpriteRenderer.color, Color.red, Mathf.PingPong(Time.time, 5));
        else if (stage_2)
            m_SpriteRenderer.color = Color.Lerp(m_SpriteRenderer.color, Color.red, Mathf.PingPong(Time.time, 5));
        else if (stage_1)
            m_SpriteRenderer.color = Color.Lerp(m_SpriteRenderer.color, Color.blue, Mathf.PingPong(Time.time, 5));
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "bullet") {
            health -= 1;
            Destroy(col.gameObject);
            audioSource.PlayOneShot(hit, 0.25F);
        }

        if (health < 90 && !stage_1) {
            camerad.GetComponent<CameraShake>().ShakeCamera(5f, 0.25f);
            audioSource.PlayOneShot(impact, 0.25F);
            stage_1 = true;
        }

        if (health < 75 && !stage_2) {
            camerad.GetComponent<CameraShake>().ShakeCamera(10f, 0.5f);
            audioSource.PlayOneShot(impact, 0.5F);
            stage_2 = true;
        }

        if (health < 50 && !stage_3) {
            camerad.GetComponent<CameraShake>().ShakeCamera(20f, 1.0f);
            audioSource.PlayOneShot(impact, 1.0F);
            stage_3 = true;
        }

        if (health <= 0 && !stage_4) {
            camerad.GetComponent<CameraShake>().ShakeCamera(40f, 10.0f);
            audioSource.PlayOneShot(death, 0.25F);
            stage_4 = true;
        }
    }
}
