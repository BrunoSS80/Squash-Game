using UnityEngine;

public class RacketHit : MonoBehaviour
{
    public float hittingTime, hit;
    public bool canHit;
    public BallController ball;
    void Start()
    {

    }

    
    void Update()
    {
        hit -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (canHit && ball != null)
            {
                canHit = false;
                hitted();
                ball.BallAttacked();
                ball = null;
            }
        }

        if(hit <= 0){
            canHit = true;
        }
    }

    public void hitted()
    {
        hit = hittingTime;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ball = other.GetComponent<BallController>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        ball = null;
    }
}
