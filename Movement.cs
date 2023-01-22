using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 5;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Transform transform;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        setDirection();
        input_management();
    }

    private void FixedUpdate() 
    {
        move();
    }

    private void setDirection()
    {
        if(moveDirection.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void input_management()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);
    }

    void move()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    public float getMoveDirectionX()
    {
        return moveDirection.x;
    } 

    public float getMoveDirectionY()
    {
        return moveDirection.y;
    }

    public float getMagnitude()
    {
        return moveDirection.sqrMagnitude;
    }

}
