using UnityEngine;
using UnityEngine.UI;

public class FollowingBall : MonoBehaviour
{
    public GameObject ball;
    public int scaleHeight, scaleWidht;
    private Camera cam;
    public RawImage rawImage;
    void Start()
    {
        scaleHeight = Camera.main.scaledPixelHeight;
        scaleWidht = Camera.main.scaledPixelWidth;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewportPos = cam.WorldToViewportPoint(ball.transform.position);
        bool isBehind = viewportPos.z < 0;
        bool isOffScreen = viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1 || isBehind;

        if (isOffScreen)
        {
            rawImage.enabled = true;
            Vector2 dir = new Vector2(viewportPos.x - 0.5f, viewportPos.y - 0.5f);

            if (isBehind){
                dir = -dir;
            }
            dir.Normalize();

            Vector2 edgePos = new Vector2(0.5f + dir.x * 0.5f, 0.5f + dir.y * 0.5f);

            edgePos.x = Mathf.Clamp01(edgePos.x);
            edgePos.y = Mathf.Clamp01(edgePos.y);

            transform.position = new Vector3(edgePos.x * Screen.width,edgePos.y * Screen.height,0);
        }
        else
        {
           rawImage.enabled = false;
        }
    }
}
