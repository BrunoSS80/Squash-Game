using UnityEngine;

public class HitController : MonoBehaviour
{
    public static HitController hitController;
    public GameObject ballPositon;
    public bool hitted;
    public bool moveHit;
    private BallController ballController;
    private PlayerController playerController; 

    void Awake()
    {
        if(hitController == null)
        {
            hitController = this;
        }
    }
    void Start()
    {
        ballController = GameManager.gameManager.ballController;
        playerController = GameManager.gameManager.playerController;
    }

    void Update()
    {
        if(hitted == true)
        {
            ballController.BallAttacked();
            hitted = false;
            playerController.animator.SetBool("Hit", false);
            playerController.playLerp = false;
        }
        if(moveHit == true && ballPositon != null)
        {
            playerController.playLerp = true;
            moveHit = false;
        }
    }
}
