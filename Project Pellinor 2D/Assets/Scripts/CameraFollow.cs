using UnityEngine;

public class CameraFollow : MonoBehaviour {
    
    #region Public Fields

    [SerializeField]
    protected Transform trackingTarget;
    [SerializeField]
    float xOffset;
    [SerializeField]
    float yOffset;
    [SerializeField]
    float followSpeed;
    [SerializeField]
    protected bool isXLocked = false;
    [SerializeField]
    protected bool isYLocked = false;
    [SerializeField]
    float zoomFactor = 1.0f;
    [SerializeField]
    float zoomSpeed = 5.0f;
    
    #endregion

    #region Private Fields

    private float originalSize = 0f;
    private Camera thisCamera;
    private float originalZoomFactor;

    #endregion

    public float OriginalZoomFactor
    {
        get{return originalZoomFactor;}
        set{originalZoomFactor = value;}
    }
    public Transform TrackingTarget    
    {
        get {return trackingTarget;}
        set {trackingTarget = value;}
    }

    private void Start() 
    {
        thisCamera = GetComponent<Camera>();
        originalSize = thisCamera.orthographicSize;
        originalZoomFactor = zoomFactor;
    }

    protected void Update()
    {
        float xTarget = trackingTarget.position.x + xOffset;
        float yTarget = trackingTarget.position.y + yOffset;

        float xNew = transform.position.x;
        float yNew = transform.position.y;
        
        

        xNew = transform.position.x;
        if (!isXLocked)
        {
            xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
        }

        yNew = transform.position.y;
        if (!isYLocked)
        {
            yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);
        }

        transform.position = new Vector3(xNew, yNew, transform.position.z);

        float targetSize = originalSize * zoomFactor;
        if (targetSize != thisCamera.orthographicSize)
        {
            thisCamera.orthographicSize = Mathf.Lerp(thisCamera.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
        }
    }    
    
    
    public void setZoom(float zoomAmount)
    {
        this.zoomFactor = zoomAmount;
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    //public Transform target;
    //public float cameraDistance = 10.0f;
    // public float boundX = 2.0f;
    // public float boundY = 1.5f; 
    // void Awake() 
    // {
    //     GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2 ) / cameraDistance);
    // }

    // void LateUpdate() 
    // {
    //     //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    //     Vector3 delta = Vector3.zero;
    //     float dx = target.position.x - transform.position.x;

    //     //x axis
    //     if (dx > boundX || dx < -boundX)
    //     {
    //         if(transform.position.x < target.position.x)
    //         {
    //             delta.x = dx - boundX;
    //         }
    //         else
    //         {
    //             delta.x = dx + boundX;
    //         }
    //     }

    //     //y axis
    //     float dy = target.position.y - transform.position.y;
    //     if (dy > boundY || dy < -boundY)
    //     {
    //         if(transform.position.y < target.position.y)
    //         {
    //             delta.y = dy - boundY;
    //         }
    //         else
    //         {
    //             delta.y = dy + boundY;
    //         }
    //     }

    //     //move camera
    //     transform.position += transform.position + delta;
    // }

}