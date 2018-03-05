using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public GameObject basket;
    private float timer;
    private float xp;
    private float yp;

    // Use this for initialization
    void Start () {
        ChangePosition();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        int counter = basket.GetComponent<GetCenter>().counter;

        timer += Time.deltaTime;
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
