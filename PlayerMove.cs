using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private InputAction movement;
    [SerializeField] private InputAction run;
    [SerializeField] private InputAction jump;
    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float rotationSpeed = 50f;

    private Animator animator;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void OnEnable()
    {
        movement.Enable();
        run.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
        run.Disable();
    }

    void Update()
    {
        Vector2 input = movement.ReadValue<Vector2>();

        bool isWalking = input.magnitude > 0.1f;
        bool isRunning = isWalking && run.IsPressed();

        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        Transform cam = Camera.main.transform;

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = camForward * input.y + camRight * input.x;

        if (moveDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );

            transform.position += moveDirection.normalized * currentSpeed * Time.deltaTime;
        }

        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning);
    }
}