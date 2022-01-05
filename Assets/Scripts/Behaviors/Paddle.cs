using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    [SerializeField] Ball ball;
    [SerializeField] float maxSpeed = 1f;

    private float horizontalDirection;

    private float playSpaceInUnits;
    private float aspect43 = 4f / 3f;
    private float limit = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        horizontalDirection = 0f;
        playSpaceInUnits = Camera.main.orthographicSize * aspect43 * 2;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float newXPosition = transform.position.x + horizontalDirection * maxSpeed;

        // Clamps the value to avoid getting off-screen
        newXPosition = Mathf.Clamp(newXPosition, limit, playSpaceInUnits - limit);

        Vector2 targetPosition = new Vector2(newXPosition, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, maxSpeed);
    }

    public void UpdateMoveDirection(InputAction.CallbackContext value)
    {
        horizontalDirection = value.ReadValue<Vector2>().x;
    }


    public void MoveLeft()
    {
        horizontalDirection = -1f;
    }

    public void MoveRight()
    {
        horizontalDirection = 1f;
    }

    public void StopMove(InputAction.CallbackContext value)
    {
        if(value.canceled == true)
        {
            horizontalDirection = 0f;
        }
    }

    public void StopMove()
    {
        horizontalDirection = 0f;
    }

    public void ShotBall(InputAction.CallbackContext value)
    {
        if (value.performed && !ball.isActive)
        {
            ball.Activate();
        }
    }

    public void ShotBall()
    {
        if (!ball.isActive)
        {
            ball.Activate();
        }
    }
}
