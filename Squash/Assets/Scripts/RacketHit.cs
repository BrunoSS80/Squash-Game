using UnityEngine;
using UnityEngine.InputSystem;

public class RacketHit : MonoBehaviour
{
    private InputAction attack;
    public float hittingTime, hit;
    private Animator animatorRacket;
    void Start()
    {
        attack = InputSystem.actions.FindAction("Attack");
        animatorRacket = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hitted();
            Debug.Log("Click");
            animatorRacket.SetTrigger("Hit");
        }
        hit -= Time.deltaTime;
    }

    public void hitted()
    {
        hit = hittingTime;
    }
}
