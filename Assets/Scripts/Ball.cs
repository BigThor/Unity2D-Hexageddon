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
    private bool isActive;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
        {
            FollowPaddle();
        }
    }

    public void Activate()
    {
        isActive = true;
        rigidBody.gravityScale = gravityScale;
        rigidBody.velocity = new Vector2(0f, maxSpeed);
    }

    private void FollowPaddle()
    {
        rigidBody.velocity = rigidBody.velocity.normalized * 0f;
        rigidBody.gravityScale = 0.0f;

        float newXPosition = 0f; // Paddle position
        if (paddle != null)
            newXPosition = paddle.transform.position.x;

        Vector2 newBallPosition = new Vector2(newXPosition, transform.position.y);
        transform.position = newBallPosition;
    }

    private void FixedUpdate()
    {
        if(rigidBody.velocity.magnitude > maxSpeed)
        {
            rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
        }
    }
}
