using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public HitController hitController;
    public BallController ballController;
    public PlayerController playerController;

    void Awake()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }
    }
}
