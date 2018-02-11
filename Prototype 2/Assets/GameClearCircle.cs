using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearCircle : MonoBehaviour {

	private Rigidbody2D rb2d;
	public bool inside;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.freezeRotation = true;
	}

	// Update is called once per frame
	void FixedUpdate () {
		GameObject clearIn = GameObject.FindGameObjectWithTag ("InnerCircle");
		GameObject clearOut = GameObject.FindGameObjectWithTag ("OuterCircle");
		CircleCollider2D i_Collider = clearIn.GetComponent<CircleCollider2D> ();
		CircleCollider2D o_Collider = clearOut.GetComponent<CircleCollider2D> ();
		CircleCollider2D m_Collider = this.GetComponent<CircleCollider2D> ();
		if (o_Collider.bounds.center.x + o_Collider.bounds.extents.x > m_Collider.bounds.center.x + m_Collider.bounds.extents.x &&
			o_Collider.bounds.center.y + o_Collider.bounds.extents.y > m_Collider.bounds.center.y + m_Collider.bounds.extents.y &&
			m_Collider.bounds.center.x + m_Collider.bounds.extents.x > i_Collider.bounds.center.x + i_Collider.bounds.extents.x &&
			m_Collider.bounds.center.y + m_Collider.bounds.extents.y > i_Collider.bounds.center.y + i_Collider.bounds.extents.y) {
			inside = true; 
		} else {
			inside = false;
		}
	}
}
