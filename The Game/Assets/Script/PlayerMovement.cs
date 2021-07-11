using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    private float prevMS;

    public Rigidbody2D rb;

    Vector2 movement;

    public Animator animator;
    private int LastDir;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x >= 1) LastDir = 0;
        else if (movement.x <= -1) LastDir = 1;
        else if (movement.y >= 1) LastDir = 2;
        else if (movement.y <= -1) LastDir = 3;

        animator.SetInteger("LastDir", LastDir);

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void respawnPlayer()
    {
        //set the player position to 0
        this.transform.position *= 0;
        //set the player movement speed to its original
        moveSpeed = prevMS;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //kill the player
        animator.SetTrigger("Died");

        //save its current movement speed
        prevMS = moveSpeed;
        //freeze the player
        moveSpeed = 0f;
        //call the respawn function after 1 sec delay
        Invoke("respawnPlayer", 1);
    }


}
