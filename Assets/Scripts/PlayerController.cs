using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private bool isOnGround;
    private Animator playerAnimation;
    private Rigidbody2D rigidBody;
    private Vector2 velocity;
    private float movement = 0f;
    private BombController bomb;

    public float speed = 3f;
    public float jumpSpeed = 7f;
    public Transform groundCheckpoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public Vector2 respawnPoint;
    public LevelManager levelManager;
    public int lifes;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        bomb = FindObjectOfType<BombController>();
        levelManager = FindObjectOfType<LevelManager>();

        respawnPoint = transform.position;

        levelManager.AddLifes(lifes);
    }


    void Update()
    {   

        isOnGround = Physics2D.OverlapCircle(groundCheckpoint.position, groundCheckRadius, groundLayer);

        movement = Input.GetAxis("Horizontal");

        if (movement > 0f) {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
            velocity.x = movement * speed;
            
        } else if (movement < 0f) {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
            velocity.x = movement * speed;     
        } else {
            velocity.x = rigidBody.velocity.x;
        }

        if (Input.GetButtonDown("Jump") && isOnGround) {
            velocity.y = jumpSpeed;
        } else {
            velocity.y = rigidBody.velocity.y;
        }

        rigidBody.velocity = velocity;

        if (rigidBody.velocity.y < 0f && !isOnGround) {
            playerAnimation.SetBool("IsFalling", true);
        } else {
            playerAnimation.SetBool("IsFalling", false);
        }

        if (isOnGround) {
            playerAnimation.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        } else {
            playerAnimation.SetFloat("Speed", 0);
        }

        playerAnimation.SetBool("OnGround", isOnGround);
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.tag == "Checkpoint") {
            respawnPoint = transform.position;
        }

        if (other.tag == "FallDetector") {
            levelManager.RemoveLifes(1);
            levelManager.Respawn();
        }

        if (other.tag == "Bomb") {
            lifes -= bomb.damage;
            levelManager.RemoveLifes(bomb.damage);
        }
    }

}
