using UnityEngine;
using UnityEngine.InputSystem;
public class Playermovement : MonoBehaviour
{
    private float movementSpeed = 4f;

    private Rigidbody2D rb;

    private Vector2 _moveDirection;
    private Vector2 _currInput;

    public InputActionReference move;
    public InputActionReference interact; //For dialogue and other options

    [SerializeField] private Animator _animator;
    private string lastDirection = "Down";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
        HandleAnim();
    }

    private void HandleAnim()
    {
        if (_animator == null) return;

        string animationName = "";

        if (_moveDirection == Vector2.zero)
        {
            animationName = "Idle";
        }
        else
        {
            animationName = "Walking";
        }
        _animator.Play(animationName + lastDirection);
    }

    private Vector3 GetDirection(Vector3 input)
    {
        Vector3 finalDirection = Vector3.zero;

        if(input.y > 0.1f)
        {
            lastDirection = "Up";
            finalDirection = new Vector2(0, 1);
        }
        else if (input.y < -0.1f)
        {
            lastDirection = "Down";
            finalDirection = new Vector2(0, -1);
        }
        else if (input.x > 0.1f)
        {
            lastDirection = "Right";
            finalDirection = new Vector2(1, 0);
        }
        else if (input.x < -0.1f)
        {
            lastDirection = "Left";
            finalDirection = new Vector2(-1, 0);
        }
        else
        {
            finalDirection = Vector2.zero;
        }

        return finalDirection;
    }

    private void OnMove(InputValue value)
    {
        _currInput = value.Get<Vector2>().normalized;
        _moveDirection = GetDirection(_currInput);
    }

    public void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(_moveDirection.x * movementSpeed, _moveDirection.y * movementSpeed);
    }

    private void OnEnable()
    {
        interact.action.started += Interaction;
    }

    private void Interaction(InputAction.CallbackContext obj)
    {
        Debug.Log("Interaction / Action button has been pressed");
    }
}