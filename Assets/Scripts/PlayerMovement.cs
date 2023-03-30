using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Input Settings")]
    public string MovementHorizontalAxis = "Horizontal";
    public string MovementVerticalAxis = "Vertical";
    public string CameraHorizontalAxis = "Mouse X";
    public string CameraVerticalAxis = "Mouse Y";
    public string JumpButton = "Jump";
    public string DashButton = "Dash";

    [Header("Parameters")]
    public Transform RotationTarget;
    public Transform Character;
    public Vector2 CameraSensitivity = new Vector2(1, 1);
    public float MoveSpeed = 10f;
    public float JumpStrength = 10f;
    public bool AirControl = false;
    public float Gravity = -30f;
    public float GroundDrag = .95f;
    public float AirDrag = .8f;
    public float DashStrength = 10f;
    public float DashDuration = .1f;
    public float DashCooldown = 2.5f;

    public ParticleSystem stunParticles;

    private CharacterController moveController;
    public CharacterController MoveController { get { return moveController; } }
    private Vector3 movement = Vector3.zero;
    private Vector3 cameraRotationAxes = Vector3.zero;
    private Vector3 CameraRotation = Vector3.zero;

    private Vector3 velocity = Vector3.zero;

    private bool hasJumped = false;
    private bool hasDashed = false;
    public bool IsDashing { get { return hasDashed; } }
    private bool canDash = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        moveController = GetComponent<CharacterController>();
    }

    void OnEnable()
    {
        if (stunParticles != null)
            stunParticles.Stop();
    }

    void OnDisable()
    {
        if (stunParticles != null)
            stunParticles.Play();
    }

    private IEnumerator TriggerDash()
    {
        hasDashed = true;
        MoveSpeed *= DashStrength;
        canDash = false;
        yield return new WaitForSeconds(DashDuration);
        MoveSpeed /= DashStrength;
        hasDashed = false;
        yield return new WaitForSeconds(DashCooldown);
        canDash = true;
    }

    void Update()
    {
        if (moveController.isGrounded && !hasDashed)
        {
            if (Input.GetButtonDown(JumpButton))
                hasJumped = true;
            if (Input.GetButtonDown(DashButton) && canDash)
                StartCoroutine(TriggerDash());
        }
        if ((AirControl || moveController.isGrounded) && !hasDashed)
            movement = new Vector3(
                Input.GetAxis(MovementHorizontalAxis),
                0f,
                Input.GetAxis(MovementVerticalAxis)
            );

        cameraRotationAxes = new Vector3(Input.GetAxis(CameraVerticalAxis) * CameraSensitivity.y, Input.GetAxis(CameraHorizontalAxis) * CameraSensitivity.x, 0);
    }

    void FixedUpdate()
    {
        CameraRotation += cameraRotationAxes * Time.fixedDeltaTime * 200;
        CameraRotation.x = Mathf.Clamp(CameraRotation.x, -89f, 89f);
        RotationTarget.rotation = Quaternion.Euler(CameraRotation);

        velocity.x = Mathf.Lerp(velocity.x, 0, moveController.isGrounded ? GroundDrag : AirDrag);
        velocity.z = Mathf.Lerp(velocity.z, 0, moveController.isGrounded ? GroundDrag : AirDrag);

        if (moveController.isGrounded)
            velocity.y = -1f;
        else
            velocity.y += Gravity * Time.fixedDeltaTime;
        if (hasJumped)
        {
            velocity.y += JumpStrength;
            hasJumped = false;
        }

        Vector3 worldMovement = RotationTarget.TransformDirection(movement);
        worldMovement.y = 0f;
        worldMovement = worldMovement.normalized * movement.magnitude;

        velocity += worldMovement * MoveSpeed;
        moveController.Move(velocity * Time.fixedDeltaTime);

        if (movement.x != 0f || movement.z != 0f)
        {
            movement.Normalize();
            float movementAngle = Mathf.Atan2(movement.x, movement.z); // == Mathf.Acos(Vector3.Dot(Vector3.forward, movement)) * Mathf.Sign(movement.x);
            float cameraAngle = Mathf.Atan2(RotationTarget.forward.x, RotationTarget.forward.z);

            Character.rotation = Quaternion.Euler(0f, (movementAngle + cameraAngle) * Mathf.Rad2Deg, 0f);
        }
    }
}