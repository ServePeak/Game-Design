using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetCenter : MonoBehaviour {

    public GameObject spawner;
    public Text timerText;
    public Text scoreText;
    public int counter;
    private float time = 0;
    private int timer;
    private Collider2D m_Collider;

    // Use this for initialization
    void Start () {
        m_Collider = GetComponent<Collider2D>();

        timer = 10;
        timerText.text = "Time Left: " + timer.ToString() + " seconds";
        counter = 5;
        scoreText.text = "Balls: " + (counter - 5).ToString();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        time += Time.deltaTime;
        if (time > 1.0f) {
            time = 0;
            timer--;
        }

        int oldCounter = counter;

        counter = 5;
        List<GameObject> bullets = spawner.GetComponent<PlayerBulletSpawner>().bullets;
        foreach (GameObject bullet in bullets) {
            if (bullet)
                if (m_Collider.bounds.Contains(bullet.transform.position)) {
                    if (bullet.GetComponent<BulletMove>().timer > 1.0f)
                        counter++;
                    else
                        bullet.GetComponent<BulletMove>().timer += Time.deltaTime;
                }
        }

        if (counter > oldCounter)
            timer = 10;

        if (timer < 0)
            SceneManager.LoadScene("Scene 1", LoadSceneMode.Single);

        scoreText.text = "Balls: " + (counter - 5).ToString();
        timerText.text = "Time Left: " + timer.ToString() + " seconds";
    }
}
