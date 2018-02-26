using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour {

    public GameObject[] players;
    public GameObject player;
    public bool myTurn = true;

	// Use this for initialization
	void Start () {
		if (myTurn) {
            player = Instantiate(players[0], new Vector2(0f,4.5f), Quaternion.identity);
            player.GetComponent<PlayerMove>().spawned = true;
            myTurn = !myTurn;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
    }

    public void SpawnPlayer() {
        if (myTurn)
            player = Instantiate(players[0], new Vector2(0f, 4.5f), Quaternion.identity);
        else
            player = Instantiate(players[1], new Vector2(0f, 4.5f), Quaternion.identity);
        player.GetComponent<PlayerMove>().spawned = true;
        myTurn = !myTurn;
    }
}
