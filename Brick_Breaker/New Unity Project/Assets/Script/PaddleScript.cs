using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{

    public float speed;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return; //stop paddle from moving the position
        }

        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);

        if(transform.position.x < -5.5f)
        {
            transform.position = new Vector2(-5.5f, transform.position.y);

        } else if (transform.position.x > 5.5f)
        {
            transform.position = new Vector2(5.5f, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("extreLife"))
        {
            gm.UpdateLives(1);
            Destroy(collision.gameObject);
        }

    }
}
