using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    public Vector3 rayHit;
    public float speedHit;
    private Rigidbody rbBall;
    void Start()
    {
        rbBall = GetComponent<Rigidbody>();
        rbBall.linearDamping = 0.2f;
        rbBall.angularDamping = 0.05f;
    }
    public void Hit(Vector3 point)
    {
        rayHit = point;
    }

    public void BallAttacked()
    {
        Vector3 directionBall = rayHit - rbBall.position;

        rbBall.linearVelocity = Vector3.zero;
        rbBall.AddForce(directionBall * speedHit, ForceMode.Impulse);   
    }
}
