using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

    public GameObject followTarget;
	public GameObject followTarget2;
    private Vector3 targetPos;
    public float moveSpeed;
    private static bool cameraexist;

    public BoxCollider2D boundBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;

    void Start()
    {
        if (!cameraexist)
        {
            cameraexist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;

        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = theCamera.orthographicSize * Screen.width / Screen.height;
    }
    void Update()
    {
		targetPos = new Vector3((followTarget.transform.position.x + followTarget2.transform.position.x)/2, (followTarget.transform.position.y+followTarget2.transform.position.y)/2, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (halfWidth > 18)
        {
            if (boundBox == null)
            {
                boundBox = FindObjectOfType<Bounds>().GetComponent<BoxCollider2D>();
                minBounds = boundBox.bounds.min;
                maxBounds = boundBox.bounds.max;
            }

            float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
            float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }

    public void SetBounds(BoxCollider2D newBounds)
    {
        boundBox = newBounds;

        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;
    }

}
