using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {

    public GameObject bullet;
    public GameObject player;

    private float timer;
    private List<GameObject> bullets = new List<GameObject>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        timer += Time.deltaTime;
        if (timer > 2.0f) {
            timer = 0;

            GameObject leftRange = GameObject.FindGameObjectWithTag("LeftRange");
            GameObject rightRange = GameObject.FindGameObjectWithTag("RightRange");
            CircleCollider2D l_Collider = leftRange.GetComponent<CircleCollider2D>();
            CircleCollider2D r_Collider = rightRange.GetComponent<CircleCollider2D>();
            CircleCollider2D p_Collider = player.GetComponent<CircleCollider2D>();

            if (!((l_Collider.bounds.center.x - l_Collider.transform.localScale.x/2 < p_Collider.bounds.center.x + p_Collider.bounds.extents.x &&
                l_Collider.bounds.center.y - l_Collider.transform.localScale.y/2 < p_Collider.bounds.center.y + p_Collider.bounds.extents.y) ^
                (l_Collider.bounds.center.x + l_Collider.transform.localScale.x / 2 > p_Collider.bounds.center.x + p_Collider.bounds.extents.x &&
                l_Collider.bounds.center.y + l_Collider.transform.localScale.y / 2 > p_Collider.bounds.center.y + p_Collider.bounds.extents.y)) ||
                !((r_Collider.bounds.center.x - r_Collider.transform.localScale.x / 2 < p_Collider.bounds.center.x + p_Collider.bounds.extents.x &&
                r_Collider.bounds.center.y - r_Collider.transform.localScale.y / 2 < p_Collider.bounds.center.y + p_Collider.bounds.extents.y) ^
                (r_Collider.bounds.center.x + r_Collider.transform.localScale.x / 2 > p_Collider.bounds.center.x + p_Collider.bounds.extents.x &&
                r_Collider.bounds.center.y + r_Collider.transform.localScale.y / 2 > p_Collider.bounds.center.y + p_Collider.bounds.extents.y))) {
                GameObject nBullet = Instantiate(bullet, this.transform.position, Quaternion.identity);
                Vector2 distance = (player.transform.position - nBullet.transform.position).normalized;
                Rigidbody2D rb = nBullet.GetComponent<Rigidbody2D>();
                rb.velocity = distance;
                bullets.Add(nBullet);
            }
        }

    }
}
