using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaHolder : MonoBehaviour
{

    private Ball ball;
    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(ball.GetComponent<Rigidbody2D>().velocity.x / 4f, ball.GetComponent<Rigidbody2D>().velocity.y / 4f);
    }
}
