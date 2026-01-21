using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public PlayerController playerController;
    public CameraController cameraController;
    private InputAction moveAction, lookAction, attackAction;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
        attackAction = InputSystem.actions.FindAction("Attack");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 movementVector = moveAction.ReadValue<Vector2>();
        playerController.Move(movementVector, cameraController.transform);

        Vector2 lookVector = lookAction.ReadValue<Vector2>();
        Vector2 lookDelta = new Vector2(-lookVector.y, lookVector.x);
        cameraController.IncrementRotationLook(lookDelta);

        playerController.Look(cameraController.lookRotation);

        if (attackAction.WasPressedThisFrame())
        {
            if(HitController.hitController.ballPositon != null)
            {
                HitController.hitController.moveHit = true;
            }
        }
    }
}
