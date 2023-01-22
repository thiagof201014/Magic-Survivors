using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 5;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        input_management();
    }

    private void FixedUpdate() 
    {
        move();
    }

    void input_management()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);
    }

    void move()
    {
        Vector2 movement = new Vector2(moveDirection.x, moveDirection.y);
        movement.Normalize();
        movement = movement * speed;

        rb.velocity = movement;
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
