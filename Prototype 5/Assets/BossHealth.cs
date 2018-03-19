using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {

    public int health = 100;
    public GameObject camerad;
    public bool stage_1;
    private bool stage_1_init;
    SpriteRenderer m_SpriteRenderer;

    // Use this for initialization
    void Start () {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (stage_1 && !stage_1_init) {
            stage_1_init = true;
        }

        if(stage_1)
            m_SpriteRenderer.color = Color.Lerp(m_SpriteRenderer.color, Color.blue, Mathf.PingPong(Time.time, 5));
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "bullet") {
            health -= 1;
            Destroy(col.gameObject);

        }

        if (health < 90 && !stage_1) {
            camerad.GetComponent<CameraShake>().ShakeCamera(10f, 0.5f);
            stage_1 = true;
        }
    }
}
