using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 10;
    [SerializeField]
    float jumpHeight = 10;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        if (move < -0.1f)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (move > 0.1f)
            transform.localScale = new Vector3(1, 1, 1);

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
        
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
