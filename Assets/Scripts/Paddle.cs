using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float maxSpeed = 3f;
    [SerializeField] Ball ball;

    private Rigidbody2D rigidBody;
    private float screenWidthInUnits = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        screenWidthInUnits = Camera.main.orthographicSize * Camera.main.aspect * 2;
    }

    // Update is called once per frame
    void Update()
    {
        FollowCursor();
        // Shot the ball when left click (0) is press
        if (Input.GetMouseButtonDown(0) && !ball.isActive)
        {
            ShotBall();
        }
    }

    private void FollowCursor()
    {
        float newXPosition = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        float limit = 0.8f;

        newXPosition = Mathf.Clamp(newXPosition, limit, screenWidthInUnits - limit);

        Vector2 newPaddlePosition = new Vector2(newXPosition, transform.position.y);
        float time = (newXPosition - transform.position.x) / maxSpeed;
        transform.position = Vector2.MoveTowards(transform.position, newPaddlePosition, maxSpeed);
    }

    private void ShotBall()
    {
        ball.Activate();
    }

    private void FixedUpdate()
    {
        if (rigidBody.velocity.magnitude > maxSpeed)
        {
            rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
        }
    }
}
