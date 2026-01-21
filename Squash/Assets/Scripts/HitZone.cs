using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour
{
    public GameObject ball;

    void Update()
    {
        
        /*
        Vector3 direciton = (targetPosition.transform.position - player.transform.position);
        Vector3 direcitonToGo = new Vector3(direciton.x, 0, direciton.z -1).normalized;
        
        characterController.Move(direcitonToGo * speed * Time.deltaTime);
        
        distance = direciton.magnitude;
        if(stopDistance >= distance)
        {
            BallController ballhit = targetPosition.GetComponent<BallController>();
            ballhit.BallAttacked();
        }*/

    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ball = other.GetComponent<GameObject>();
            HitController.hitController.ballPositon = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        ball = null;
        HitController.hitController.ballPositon = null;
    }







            //targetPosition = other.transform.position;
            //startPosition = player.transform.position;
            //lerp = true;
           /* startPositionBall = other.bounds.center;
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
            }*/
}
