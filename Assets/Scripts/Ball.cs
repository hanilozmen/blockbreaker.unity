using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public Paddle paddle;
    public float xVelocity, yVelocity;
    public AudioClip[] clips;
    public float randomFactor = 0.2f;
    
    private bool isStarted = false;
    private Vector2 paddleToBallVector;

    private AudioSource audioSource;
    private Rigidbody2D rigidBody;
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
        GetComponent<Rigidbody2D>()
    }

    void Update()
    {
        if (!isStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        transform.position = new Vector2(paddle.transform.position.x, paddle.transform.position.y) + paddleToBallVector;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidBody.velocity = new Vector2(xVelocity, yVelocity);
            isStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (isStarted)
        {
            AudioClip clip = clips[Random.Range(0, clips.Length)];
            audioSource.PlayOneShot(clip);
        }
    }
}