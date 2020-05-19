using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay; // ture - moving around . false - ball to be on paddle.
    public Transform paddle;
    public float speed;
    public Transform explosion;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // get the rigid body reference

      
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }
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
            gm.UpdatrLives(-1);

        }
    }
    //When the ball hits the Collision2D that are not a trigger.
    void OnCollisionEnter2D(Collision2D other)
    {
        // in OnCollisionEnter2D Collision2D dont have CompareTag, but other.transform have..
        if (other.transform.CompareTag("brick"))
        {
            Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(newExplosion.gameObject, 2.5f);

            gm.UpdateScore(other.gameObject.GetComponent<BrickScript>().points);

            Destroy(other.gameObject);
        }
    }
}
