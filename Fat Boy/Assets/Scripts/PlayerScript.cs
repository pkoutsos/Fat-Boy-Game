using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5;
    public float jumpdSpeed = 8f;
    private float movement = 0f;
    private Rigidbody2D rigidBody2D;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingTerrain;
    private Animator playerAnimation;
    public Vector3 respawnPoint;
    public Vector3 startPoint;
    public LevelScript levelscript;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent <Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
        startPoint = transform.position;
        levelscript = FindObjectOfType<LevelScript>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingTerrain = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            rigidBody2D.velocity = new Vector2(movement * speed, rigidBody2D.velocity.y);
            transform.localScale = new Vector2(1f, 1f);
        }

        else if (movement < 0f)
        {
            rigidBody2D.velocity = new Vector2(movement * speed, rigidBody2D.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);
        }
        else
        {
            rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);
        }

        if(Input.GetButtonDown ("Jump") && isTouchingTerrain)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpdSpeed);
        }

        playerAnimation.SetFloat ("Speed", Mathf.Abs (rigidBody2D.velocity.x));
        playerAnimation.SetBool("OnTerrain", isTouchingTerrain);

       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "FallDetector")
        {
            //when player goes to FallDetector zone
            //transform.position = respawnPoint;
            levelscript.Respawn();
        }
        if(other.tag == "CheckPoint")
        {
            respawnPoint = other.transform.position;
        }

        if(other.tag == "FinishFlag")
        {
            levelscript.GameCompleted();
            //Destroy(other.gameObject);
        }

    }

}
