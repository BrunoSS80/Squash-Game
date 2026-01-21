using UnityEngine;

public class RacketHit : MonoBehaviour
{
    public bool hit;

    void Update()
    {
        if(hit == true)
        {
            HitController.hitController.hitted = hit;
        }
    }
}
