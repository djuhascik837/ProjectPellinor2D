using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float cameraDistance = 10.0f;

    void Awake() 
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2 ) / cameraDistance);
    }

    void LateUpdate() 
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

}