using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    public Vector3 rayHit;
    public float speedHit;
    private InputAction attack;
    private Rigidbody rbBall;
    private Vector3 lastVelocity;
    private bool hitBall, hittingBall;
    void Start()
    {
        rbBall = GetComponent<Rigidbody>();
        attack = InputSystem.actions.FindAction("Attack");
        rbBall.linearDamping = 0.2f;
        rbBall.angularDamping = 0.05f;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hitBall = true;
        }
    }
    void FixedUpdate()
    {
        //lastVelocity = rbBall.linearVelocity;
        if (!hitBall) return;
        hitBall = false;

        Vector3 directionBall = rayHit - rbBall.position;

        rbBall.linearVelocity = Vector3.zero;
        rbBall.AddForce(directionBall * speedHit, ForceMode.Impulse);

        //hittingBall = true;
    }
    private void OnCollisionEnter(Collision other)
    {
        /*if (hittingBall)
        {
            hittingBall = false;
            return;
        }
        if (other.contactCount > 0)
        {
            Vector3 normal = other.contacts[0].normal;
            Vector3 reflected = Vector3.Reflect(lastVelocity, normal).normalized;
            float speed = Mathf.Clamp(lastVelocity.magnitude, 10, 20);

            rbBall.linearVelocity = reflected * speed;
        }*/
    }
    public void Hit(Vector3 point)
    {
        rayHit = point;
    }
}
