using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    float cameraWidth;
    float halfPaddleSize;

    private GameStatus gameStatus;
    private Ball ball;

    void Start()
    {
        cameraWidth = calculateCameraSize();
        ball = FindObjectOfType<Ball>();
        gameStatus = FindObjectOfType<GameStatus>();
        transform.position = new Vector3(cameraWidth/2, transform.position.y, transform.position.z);
        halfPaddleSize = GetComponent<Collider2D>().bounds.size.x / 2.0f;
    }

    private float calculateCameraSize()
    {
        float screenAspect = (float) Screen.width / (float) Screen.height;
        float camHalfHeight = FindObjectOfType<Camera>().orthographicSize;
        float camHalfWidth = screenAspect * camHalfHeight;
        return 2.0f * camHalfWidth;
    }

    // Update is called once per frame
    void Update(){
        float maxPos = cameraWidth - halfPaddleSize;
        float xPos = GetXPos();
        xPos = Mathf.Clamp(xPos, halfPaddleSize, cameraWidth - halfPaddleSize);
        Vector2 paddlePos = new Vector3(xPos, transform.position.y,transform.position.z);
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
