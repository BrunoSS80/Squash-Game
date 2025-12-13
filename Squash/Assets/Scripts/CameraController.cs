using UnityEngine;
using UnityEngine.InputSystem;

[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{
    public PlayerController playerController;
    public Transform cameraTarget;
    public float targetHeight = 1;
    public Vector2 XRotationRange = new Vector2(-70, 50);
    private Vector2 targetLook;

    public Quaternion lookRotation => cameraTarget.transform.rotation;
    void LateUpdate()
    {
        cameraTarget.transform.position = playerController.transform.position + Vector3.up * targetHeight;
        cameraTarget.transform.rotation = Quaternion.Euler(targetLook.x, targetLook.y, 0);
    }

    public void IncrementRotationLook(Vector2 lookDelta)
    {
        targetLook += lookDelta;
        targetLook.x = Mathf.Clamp(targetLook.x, XRotationRange.x, XRotationRange.y);
    }
}
