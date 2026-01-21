using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private CharacterController characterController;
  public InputHandler inputHandler;
  public float movementSpeed = 10, lookSpeed = 2, waitTime = 2;
  public Animator animator;
  public float stopDistance;
  public bool playLerp;
  void Start()
  {
    characterController = GetComponent<CharacterController>();
    animator = GetComponent<Animator>();
  }

  void Update()
  {
    if (playLerp)
    {
      animator.SetBool("Hit",true);
      Vector3 positionBall = HitController.hitController.ballPositon.transform.position;
      Vector3 direciton = (positionBall - transform.position);
      Vector3 direcitonToGo = new Vector3(direciton.x, 0, direciton.z - 1).normalized;
      float distance = direciton.magnitude;

      if (stopDistance <= distance)
      {
        characterController.Move(direcitonToGo * movementSpeed * Time.deltaTime);
      }
    }
  }

  public void Move(Vector2 movementVector, Transform cameraTransform)
  {
    Vector3 moveForward = cameraTransform.forward;
    moveForward.y = 0;

    Vector3 moveRight = cameraTransform.right;
    moveRight.y = 0;

    Vector3 moveDir = moveForward * movementVector.y + moveRight * movementVector.x;
    moveDir.Normalize();

    characterController.Move(moveDir * movementSpeed * Time.deltaTime);
  }

  public void MoveLerp(Vector3 positionBall)
  {
    animator.SetTrigger("Hit");
    Vector3 direciton = (positionBall - transform.position);
    Vector3 direcitonToGo = new Vector3(direciton.x, 0, direciton.z - 1).normalized;
    float distance = direciton.magnitude;

    if (stopDistance <= distance)
    {
      StartCoroutine(PlayerLerp(direcitonToGo));
    }
  }
  public void Look(Quaternion lookVector)
  {
    lookVector.x = 0;
    lookVector.z = 0;
    transform.rotation = Quaternion.Lerp(transform.rotation, lookVector, lookSpeed * Time.deltaTime);
  }

  IEnumerator PlayerLerp(Vector3 moveDir)
  {
    float elapsedTime = 0;
    while (elapsedTime < waitTime)
    {
      characterController.Move(moveDir * movementSpeed * Time.deltaTime);
      elapsedTime += Time.deltaTime;
      yield return null;
    }
  }
}
