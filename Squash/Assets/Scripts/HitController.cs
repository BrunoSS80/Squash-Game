using UnityEngine;

public class HitController : MonoBehaviour
{
    public Vector3 balPositon;
    public HitController hitController;
    void Awake()
    {
        if(hitController == null)
        {
            hitController = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
