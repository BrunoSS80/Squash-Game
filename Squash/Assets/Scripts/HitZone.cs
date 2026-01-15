using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour
{
    public float cooldown, timeCooldown;
    public bool canHit;
    public Rigidbody ball;

    private Vector3 startPositionBall;
    private Vector3 startForceBall;
    public float timeBetweenPoints;
    public int pontosCalculo;
    public List<Vector3> positionsBall;
    public Vector3 closePosition;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canHit == true && ball != null)
            {
                canHit = false;
                cooldown = timeCooldown;
                
                ball = null;
            }
        }
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        if(cooldown <= 0){
            canHit = true;
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ball = other.GetComponent<Rigidbody>();
            startPositionBall = other.bounds.center;
            startForceBall = ball.linearVelocity;

            for(int i = 0; i <= pontosCalculo; i++)
            {
                float t = i * timeBetweenPoints;
                Vector3 posBall = startPositionBall + startForceBall * t+ t * 0.5f * Physics.gravity * t*t;
                positionsBall.Add(posBall);
            }
            foreach(Vector3 posFuture in positionsBall)
            {
                if(posFuture.y <= 1.3 && posFuture.y >= 1.2)
                {
                    closePosition = posFuture;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        ball = null;
    }
}
