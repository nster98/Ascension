using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public SpriteRenderer render;
    public float speedY;
    public float jumpSpeed;

    private bool isMoving;

    private enum Side {Left, Right};
    private Side side;
    
    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;

        side = Side.Left;
    }

    // Update is called once per frame
    void Update()
    {
        // Code for input
        // Touch to move to the other side
        // Swipe in the direction of movement to swing on the thingy
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isMoving = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            isMoving = true;
        }
    }

    // Physics here
    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speedY);

        if (isMoving == true && side == Side.Left)
        {
            transform.Translate(Vector2.right * Time.deltaTime * jumpSpeed);
            render.flipX = true;
        }
        else if (isMoving == true && side == Side.Right)
        {
            transform.Translate(Vector2.left * Time.deltaTime * jumpSpeed);
            render.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag == "Wall" && transform.position.x < 0)
        {
            isMoving = false;
            side = Side.Left;
        }
        if (collision.gameObject.tag == "Wall" && transform.position.x > 0)
        {
            isMoving = false;
            side = Side.Right;
        }
    }
}
