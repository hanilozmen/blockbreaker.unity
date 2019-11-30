using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleHolder : MonoBehaviour
{

    public Ball ball;

    private void Awake()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), ball.gameObject.GetComponent<Collider2D>(), true);
    }

}
