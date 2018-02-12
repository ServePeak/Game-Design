using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LevelOne() {
        SceneManager.LoadScene("Screen 1", LoadSceneMode.Single);
    }

    public void LevelTwo() {
        SceneManager.LoadScene("Scene 2", LoadSceneMode.Single);
    }

    public void LevelThree() {
        SceneManager.LoadScene("Scene 3", LoadSceneMode.Single);
    }
}
