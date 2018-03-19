using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour {

    public GameObject camerad;
    private float time;
    private bool timeMove;
    private float time2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (timeMove)
            time2 += Time.deltaTime;

        if (time2 < 1.0f && timeMove) {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("player").transform.position, Time.deltaTime);
        } else {
            timeMove = false;
            time2 = 0;
            time += Time.deltaTime;
        }

        if (GetComponent<BossHealth>().stage_3 && time > 1.0f) {
            timeMove = true;
            time = 0;
            camerad.GetComponent<CameraShake>().ShakeCamera(1f, 0.1f);
        }
	}
}
