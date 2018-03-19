using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWin : MonoBehaviour {

    public Text canvasText1;
    public GameObject boss;
    private float time;

    // Use this for initialization
    void Start () {
        canvasText1.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (boss.GetComponent<BossHealth>().stage_4) {
            time += Time.deltaTime;
            if (time > 5.0f)
                canvasText1.enabled = true;
        }
    }
}
