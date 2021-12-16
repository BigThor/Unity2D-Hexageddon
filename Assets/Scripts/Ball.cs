using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float maxSpeed = 9f;
    [SerializeField] float gravityScale = 0.4f;
    [SerializeField] Paddle paddle;

    // Start is called before the first frame update

    private Rigidbody2D rigidBody;
    private AudioSource bounceAudio;
    public bool isActive { get; private set; }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        bounceAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
        {
            FollowPaddle();
        }
    }

    private void FollowPaddle()
    {
        float zeroVelocity = 0f;
        rigidBody.velocity = rigidBody.velocity.normalized * zeroVelocity;
        rigidBody.gravityScale = 0.0f;

        float paddleXPosition = paddle != null ? paddle.transform.position.x : 0f;

        Vector2 newBallPosition = new Vector2(paddleXPosition, transform.position.y);
        transform.position = newBallPosition;
    }

    private void FixedUpdate()
    {
        if (!isActive)
            return;
        Vector2 normalizedSpeed = rigidBody.velocity.normalized;
        
        // Changes the angle if its speed is 0 in x or y component
        if(Mathf.Abs(normalizedSpeed.x) < 0.1)
        {
            normalizedSpeed.x = generateRandomComponent(normalizedSpeed.x);
        }
        if (Mathf.Abs(normalizedSpeed.y) < 0.1)
        {
            normalizedSpeed.y = generateRandomComponent(normalizedSpeed.y);
        }

        // Limits speed to maxSpeed
        rigidBody.velocity = normalizedSpeed * maxSpeed;
    }

    private float generateRandomComponent(float sign)
    {
        return Random.Range(0.1f, 0.3f) * Mathf.Sign(sign);
    }

    // Activates de Ball and shots it at maxSpeed on Y
    public void Activate()
    {
        isActive = true;
        rigidBody.gravityScale = gravityScale;
        rigidBody.velocity = new Vector2(0f, maxSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bounceAudio.Play();
    }
}
