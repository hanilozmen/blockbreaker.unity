using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaHolder : MonoBehaviour
{

    public Ball ball;
    private void OnTriggerEnter2D(Collider2D other)
    {
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(ball.GetComponent<Rigidbody2D>().velocity.x / 3f, ball.GetComponent<Rigidbody2D>().velocity.y / 3f);
    }
}
