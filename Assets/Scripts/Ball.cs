using UnityEngine;

public class Ball : MonoBehaviour
{
    public Paddle paddle;
    public float xVelocity, yVelocity;
    public AudioClip[] clips;
    public float randomFactor;
    
    private bool isStarted = false;
    private Vector3 paddleToBallVector;

    private AudioSource audioSource;
    private Rigidbody2D rigidBody;
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
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
        transform.position = new Vector3(paddle.transform.position.x, paddle.transform.position.y, paddle.transform.position.z) + paddleToBallVector;
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
            // Vector2 velocityRandom = new Vector2(Random.Range(0, randomFactor),Random.Range(0, randomFactor));
            // rigidBody.velocity += velocityRandom; // to prevent infinite movements
            AudioClip clip = clips[Random.Range(0, clips.Length)];
            audioSource.PlayOneShot(clip);
        }
    }
}