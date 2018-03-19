using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {

    public int health = 100;
    public GameObject camerad;
    public bool stage_1;
    public bool stage_2;
    public bool stage_3;
    public bool stage_2_init;
    private bool stage_3_init;
    SpriteRenderer m_SpriteRenderer;

    // Use this for initialization
    void Start () {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {


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

        }

        if (health < 90 && !stage_1) {
            camerad.GetComponent<CameraShake>().ShakeCamera(5f, 0.25f);
            stage_1 = true;
        }

        if (health < 75 && !stage_2) {
            camerad.GetComponent<CameraShake>().ShakeCamera(10f, 0.5f);
            stage_2 = true;
        }

        if (health < 50 && !stage_3) {
            camerad.GetComponent<CameraShake>().ShakeCamera(20f, 1.0f);
            stage_3 = true;
        }
    }
}
