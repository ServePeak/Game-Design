using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

    public GameObject inside;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        var mousePos = Input.mousePosition;

        Collider2D i_Collider = inside.GetComponent<Collider2D>();
        Collider2D m_Collider = GetComponent<Collider2D>();
        bool is_inside = i_Collider.bounds.Contains(m_Collider.bounds.max) && i_Collider.bounds.Contains(m_Collider.bounds.min);

        if (!is_inside) {
            mousePos.z = 10;
        }

        transform.position = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButtonDown(0)) {
            if (is_inside) {
                Debug.Log("you can't do that!");
            } else {
                Debug.Log("placing your object down");
            }
        }
    }
}
