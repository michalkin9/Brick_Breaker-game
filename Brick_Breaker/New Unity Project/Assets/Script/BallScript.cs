using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay; // ture - moving around . false - ball to be on paddle.
    public Transform paddle;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // get the rigid body reference

      
    }

    // Update is called once per frame
    void Update()
    {
        if (!inPlay) //if false..
        {
            transform.position = paddle.position;
        }

        if (Input.GetButtonDown("Jump") && !inPlay ) 
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed); // gives the ball force for begging. 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //runs evert time the objuect collides the collider
    {
        if (collision.CompareTag("bottom"))//if the tag is bottom 
        {
            Debug.Log("Ball hits bottom edge of the screen"); //test detection
           
            rb.velocity = Vector2.zero; //kill momentom of the object.
            inPlay = false; //will starts the ball follow the paddle;


        }
    }
}
