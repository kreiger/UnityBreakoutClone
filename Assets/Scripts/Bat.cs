using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0);
        rb.velocity = move * speed;
        //transform.position += move * speed * Time.deltaTime;
        //rb.velocity = Vector2.zero;
    }
    
    void OnCollisionEnter2D(Collision2D collision) {
  	    if (collision.gameObject.CompareTag("Ball")) {
	        Vector2 diff = transform.position - collision.transform.position; 
            collision.rigidbody.velocity -= new Vector2(diff.x * 2, 0);
            collision.rigidbody.velocity += rb.velocity * 0.5f;
        }
    }
}
