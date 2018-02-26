using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetWin : MonoBehaviour {

    public int hort_inside;
    public int vert_inside;
    public int first_diag;
    public int second_diag;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (GetComponent<PlayerMove>().destroyable) {
            hort_inside = 0;
            vert_inside = 0;
            first_diag = 0;
            second_diag = 0;
            List<GameObject> similar = new List<GameObject>();
            foreach(GameObject obj in GameObject.FindGameObjectsWithTag(gameObject.tag)) {
                if(obj.GetComponent<PlayerMove>().destroyable)
                    similar.Add(obj);
            }

            Collider2D m_Collider = GetComponent<Collider2D>();
            Bounds horizontal = new Bounds(m_Collider.bounds.center, new Vector3(2.6f, 0.7f, 0f));
            Bounds vertical = new Bounds(m_Collider.bounds.center, new Vector3(0.7f, 2.6f, 0f));
            Bounds diag1 = new Bounds(new Vector3(m_Collider.bounds.center.x + 1.0f, m_Collider.bounds.center.y + 1.0f, 0f), new Vector3(0.4f, 0.4f, 0f));
            Bounds diag2 = new Bounds(new Vector3(m_Collider.bounds.center.x - 0.3f, m_Collider.bounds.center.y - 0.3f, 0f), new Vector3(0.4f, 0.4f, 0f));
            Bounds diag3 = new Bounds(new Vector3(m_Collider.bounds.center.x - 0.3f, m_Collider.bounds.center.y + 1.0f, 0f), new Vector3(0.4f, 0.4f, 0f));
            Bounds diag4 = new Bounds(new Vector3(m_Collider.bounds.center.x + 1.0f, m_Collider.bounds.center.y - 0.3f, 0f), new Vector3(0.4f, 0.4f, 0f));
            foreach (GameObject obj in similar) {
                Collider2D o_Collider = obj.GetComponent<Collider2D>();
                if (horizontal.Contains(o_Collider.bounds.max))
                    hort_inside++;
                if (vertical.Contains(o_Collider.bounds.max))
                    vert_inside++;
                if (diag1.Contains(o_Collider.bounds.max))
                    first_diag++;
                if (diag2.Contains(o_Collider.bounds.max))
                    first_diag++;
                if (diag3.Contains(o_Collider.bounds.max))
                    second_diag++;
                if (diag4.Contains(o_Collider.bounds.max))
                    second_diag++;
            }
            if (hort_inside >= 3 || vert_inside >= 3 || first_diag >= 2 || second_diag >= 2) { 
                if (gameObject.tag == "x")
                    SceneManager.LoadScene("X Win", LoadSceneMode.Single);
                else if (gameObject.tag == "o")
                    SceneManager.LoadScene("O Win", LoadSceneMode.Single);
            }

        }
    }
}
