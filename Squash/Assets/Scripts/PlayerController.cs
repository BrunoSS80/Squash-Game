using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    public InputHandler inputHandler;
    public float movementSpeed = 10, lookSpeed = 2;
    public Animator animator;
    void Start()
    {
      characterController = GetComponent<CharacterController>();  
      animator = GetComponent<Animator>();
    }

    void Update()
    {
    if (Input.GetKeyDown(KeyCode.H))
    {
      animator.SetTrigger("Hit");
    }
    }

    public void Move(Vector2 movementVector, Transform cameraTransform)
    {
      Vector3 moveForward = cameraTransform.forward;
      moveForward.y = 0;
       
      Vector3 moveRight = cameraTransform.right;
      moveRight.y=0;

      Vector3 moveDir = moveForward * movementVector.y + moveRight * movementVector.x;
      moveDir.Normalize();
      
      characterController.Move(moveDir * movementSpeed * Time.deltaTime);
    }

    public void Look(Quaternion lookVector)
    {
      lookVector.x = 0;
      lookVector.z = 0;
      transform.rotation = Quaternion.Lerp(transform.rotation, lookVector, lookSpeed * Time.deltaTime);
    }
}
