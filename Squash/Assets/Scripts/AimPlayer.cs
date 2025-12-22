using UnityEngine;
using UnityEngine.InputSystem;

public class AimPlayer : MonoBehaviour
{
    private LayerMask layerMask;
    public BallController ballController;
    void Awake()
    {
        layerMask = LayerMask.GetMask("Ground");
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100f, layerMask))
        {
            ballController.Hit(hit.point);
        }
    }
}
