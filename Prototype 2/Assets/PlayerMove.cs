using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour {

	private Rigidbody2D rb2d;
	public GameObject[] balls;
	public int numInside;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal*2, moveVertical*2);
		rb2d.AddForce (movement);

		numInside = 0;
		foreach (GameObject ball in balls) {
			if (ball.tag == "BallSquare" && ball.GetComponent<GameClearSquare> ().inside) {
				numInside++;
			} else if (ball.tag == "BallCircle" && ball.GetComponent<GameClearCircle> ().inside) {
				numInside++;
			}
		}
		if (numInside == balls.Length) {
			Scene scene = SceneManager.GetActiveScene ();
			if (scene.name == "Screen 1") {
				SceneManager.LoadScene ("Scene 2", LoadSceneMode.Single); 
			} else if (scene.name == "Scene 2") {
				SceneManager.LoadScene ("Scene 3", LoadSceneMode.Single); 
			} else if (scene.name == "Scene 3") {
				SceneManager.LoadScene ("You Win", LoadSceneMode.Single); 
			}
		}
	}
}
