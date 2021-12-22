using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    [SerializeField] Ball ball;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] float maxSpeed = 1f;

    private float horizontalDirection;

    private float halfScreenWidthInPixels;
    private float playSpaceInUnits;
    private float aspect43 = 4f / 3f;
    private float limit = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        horizontalDirection = 0f;
        playSpaceInUnits = Camera.main.orthographicSize * aspect43 * 2;
        halfScreenWidthInPixels = Screen.width / 2f;
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
        // Process coordinates of touch to determinate direction
        if (playerInput != null && playerInput.currentControlScheme.Equals("Touch"))
        {
            // Get coordinate x of touch position
            float horizontalMove = value.ReadValue<Vector2>().x;
            horizontalMove -= halfScreenWidthInPixels;

            // Clamp values to 1 or -1
            horizontalDirection = Mathf.Clamp(horizontalMove, -1f, 1f);
            return;
        }

        horizontalDirection = value.ReadValue<Vector2>().x;
    }

    public void StopMove(InputAction.CallbackContext value)
    {
        if(value.canceled == true)
        {
            horizontalDirection = 0f;
        }
    }

    public void ShotBall(InputAction.CallbackContext value)
    {
        if (value.performed && !ball.isActive)
        {
            ball.Activate();
        }
    }
}
