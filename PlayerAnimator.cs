using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private Movement movement;
    private SpriteRenderer spriteRenderer;
    private Transform transform;
    private float lastVertical;
    private float lastHorizontal;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<Movement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        setAnimation();

        rotateSprite();
    } 

    private void setAnimation()
    {
        // Sets the walking animations
        animator.SetFloat("Horizontal", movement.getMoveDirectionX());
        animator.SetFloat("Vertical", movement.getMoveDirectionY());
        animator.SetFloat("Speed", movement.getMagnitude());

        // Sets the idle animations
        if(movement.getMoveDirectionY() != 0 && movement.getMoveDirectionX() == 0)
        {
            lastVertical = movement.getMoveDirectionY();

            animator.SetFloat("LastVertical", lastVertical);
            animator.SetFloat("LastHorizontal", 0);
        }
        if(movement.getMoveDirectionY() == 0 && movement.getMoveDirectionX() != 0)
        {
            lastHorizontal = movement.getMoveDirectionX();

            animator.SetFloat("LastHorizontal", lastHorizontal);
            animator.SetFloat("LastVertical", 0);
        }
    }

    // Rotates de player sprite when facing left
    private void rotateSprite()
    {
        // Rotates when the player is walking
        if(movement.getMoveDirectionX() < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        // Rotates when the player is idle
        if(movement.getMagnitude() == 0 && lastHorizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(movement.getMagnitude() == 0 && lastHorizontal >= 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
