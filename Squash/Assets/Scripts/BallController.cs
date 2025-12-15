using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    public Vector3 rayHit;
    public float speedHit;
    private InputAction attack;
    private Rigidbody rbBall;
    void Start()
    {
        rbBall = GetComponent<Rigidbody>();
        attack = InputSystem.actions.FindAction("Attack");
    }
    void FixedUpdate()
    {
        Vector3 directionBall = rayHit - rbBall.transform.position;
        if (attack.IsPressed())
        {
            rbBall.linearVelocity = Vector3.zero;
            rbBall.angularVelocity = Vector3.zero;
            rbBall.AddForce(directionBall * speedHit, ForceMode.Impulse);
        }
    }
    public void Hit(Vector3 point)
    {
        rayHit = point;
    }
}
