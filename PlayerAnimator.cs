using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    Movement movement;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<Movement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", movement.getMoveDirectionX());
        animator.SetFloat("Vertical", movement.getMoveDirectionY());
        animator.SetFloat("Speed", movement.getMagnitude());
    }
}
