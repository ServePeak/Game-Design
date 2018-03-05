using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public GameObject basket;
    public SpriteRenderer m_SpriteRenderer;
    private float timer;
    private float timeColor;
    private float xp;
    private float yp;

    // Use this for initialization
    void Start () {
        ChangePosition();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        int counter = basket.GetComponent<GetCenter>().counter;

        timer += Time.deltaTime;
        timeColor += Time.deltaTime;
        if (timeColor > 5.0f - Mathf.Log(counter+1, 10)) {
            timeColor = 0;

            if (m_SpriteRenderer.color != Color.black)
                m_SpriteRenderer.color = Color.black;
            else {
                int color = Random.Range(0, 2);
                if (color == 0)
                    m_SpriteRenderer.color = Color.green;
                else
                    m_SpriteRenderer.color = Color.red;
            }
        }
        if (timer > 5.0f - Mathf.Log(counter, 10)) {
            timer = 0;

            ChangePosition();
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(xp, yp, 0), Mathf.Log(counter, 2) * 5.0f * Time.deltaTime);

        if (transform.position.x == xp && transform.position.y == yp)
            ChangePosition();
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 30f, Vector3.forward);
    }

    void ChangePosition() {
        xp = Random.Range(-10.3f, 10.3f);
        yp = Random.Range(-5f, 5f); ;
    }
}
