using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public readonly float cameraWidth = 32f;
    public readonly float halfPaddleSize = 2f;

    private GameStatus gameStatus;
    private Ball ball;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameStatus = FindObjectOfType<GameStatus>();
        transform.position = new Vector2(cameraWidth/2, transform.position.y);
    }

    // Update is called once per frame
    void Update(){
        float maxPos = cameraWidth - halfPaddleSize;
        float xPos = GetXPos();
        xPos = Mathf.Clamp(xPos, halfPaddleSize, cameraWidth - halfPaddleSize);
        Vector2 paddlePos = new Vector2(xPos, transform.position.y);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (gameStatus.isAutoPlayEnabled)
        {
            return ball.transform.position.x;
        }
        return (Input.mousePosition.x / Screen.width * 1f) * cameraWidth;
    }
}
