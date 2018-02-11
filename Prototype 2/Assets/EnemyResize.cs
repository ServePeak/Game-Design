using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyResize : MonoBehaviour {

	public float distance;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		distance = Mathf.Max(0.5f,Mathf.Min(5.0f, Vector3.Distance (player.transform.position, this.transform.position)))/5;
		this.transform.localScale = new Vector3 (distance, distance, distance);
	}
}
