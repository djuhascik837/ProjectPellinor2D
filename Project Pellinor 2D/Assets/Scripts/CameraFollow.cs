using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    //public float cameraDistance = 10.0f;
    public float boundX = 2.0f;
    public float boundY = 1.5f; 
    // void Awake() 
    // {
    //     GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2 ) / cameraDistance);
    // }

    void LateUpdate() 
    {
        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        Vector3 delta = Vector3.zero;
        float dx = target.position.x - transform.position.x;

        //x axis
        if (dx > boundX || dx < -boundX)
        {
            if(transform.position.x < target.position.x)
            {
                delta.x = dx - boundX;
            }
            else
            {
                delta.x = dx + boundX;
            }
        }

        //y axis
        float dy = target.position.y - transform.position.y;
        if (dy > boundY || dy < -boundY)
        {
            if(transform.position.y < target.position.y)
            {
                delta.y = dy - boundY;
            }
            else
            {
                delta.y = dy + boundY;
            }
        }

        //move camera
        transform.position += transform.position + delta;
    }

}