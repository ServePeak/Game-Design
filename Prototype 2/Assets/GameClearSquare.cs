using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearSquare : MonoBehaviour {

	private Rigidbody2D rb2d;
	public bool inside;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.freezeRotation = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GameObject clearIn = GameObject.FindGameObjectWithTag ("InnerSquare");
		GameObject clearOut = GameObject.FindGameObjectWithTag ("OuterSquare");
		Collider2D i_Collider = clearIn.GetComponent<Collider2D> ();
		Collider2D o_Collider = clearOut.GetComponent<Collider2D> ();
		Collider2D m_Collider = this.GetComponent<Collider2D> ();
		if (o_Collider.bounds.Contains (m_Collider.bounds.max) && o_Collider.bounds.Contains (m_Collider.bounds.min) &&
		    m_Collider.bounds.Contains (i_Collider.bounds.max) && m_Collider.bounds.Contains (i_Collider.bounds.min)) {
			inside = true; 
		} else {
			inside = false;
		}

        if (o_Collider.bounds.Contains(m_Collider.bounds.max) && o_Collider.bounds.Contains(m_Collider.bounds.min)) {
            rb2d.drag = 3f;
        } else {
            rb2d.drag = 0.5f;
        }
	}
}
