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
            return;
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
}
