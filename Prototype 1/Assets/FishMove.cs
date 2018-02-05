using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FishMove : MonoBehaviour {

	private Rigidbody2D rb2d;
	private float timer;
	public int score = 0;

	public Text ScoreText;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		score = 0;
		ScoreText.text = "Score: " + score.ToString ();
		rb2d.freezeRotation = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (score == 100)
            SceneManager.LoadScene("You Win", LoadSceneMode.Single);

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal*2, moveVertical*2);
		rb2d.AddForce (movement);

		timer += Time.deltaTime;

		if (timer > 1f) {

			score += 1;

			//We only need to update the text if the score changed.
			ScoreText.text = "Score: " + score.ToString();

			//Reset the timer to 0.
			timer = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D other)	{
		if(other.gameObject.tag=="Shark" || other.gameObject.tag=="Net" || other.gameObject.tag=="Hook")
			SceneManager.LoadScene("Game Over", LoadSceneMode.Single);      
	}
}
