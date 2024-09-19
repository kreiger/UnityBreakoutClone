using UnityEngine;

public class Ball : MonoBehaviour {
    Rigidbody2D rb;
    public float maxVelocity;
    public float minVelocity;
    public float minHorizontalDegrees = 30f;
    public Animator camAnim;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        rb.velocity = new Vector2(1, 5);
    }
    
    void OnCollisionEnter2D(Collision2D col) {
        string tag = col.gameObject.tag; 
        if (tag == "Wall" || tag == "Bat") {
            GetComponent<AudioSource>().Play();
        }
        camAnim.SetTrigger("ScreenShake");
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (!spriteRenderer.isVisible) {
            var bat = GameObject.FindWithTag("Bat");
            transform.position = bat.transform.position + Vector3.up;
            rb.velocity = new Vector2(1, 5);
            return;
        }

        var velocity = rb.velocity;
        if (velocity.y == 0) {
            rb.velocity = new Vector2(velocity.x, -velocity.x);
        }
        else {
            var minY = Mathf.Tan(Mathf.Deg2Rad * minHorizontalDegrees);
            if (Mathf.Abs(velocity.y) / Mathf.Abs(velocity.x) < minY) {
                rb.velocity = new Vector2(velocity.x, Mathf.Abs(velocity.x) * minY * Mathf.Sign(velocity.y));
            }
        }

        velocity = rb.velocity;
        if (velocity.magnitude < minVelocity) {
            rb.velocity = velocity * (minVelocity / velocity.magnitude);
        }
        else {
            rb.velocity = Vector2.ClampMagnitude(velocity, maxVelocity);
        }
    }
}
