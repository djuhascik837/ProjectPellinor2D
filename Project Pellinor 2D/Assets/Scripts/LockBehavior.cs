using UnityEngine;

public class LockBehavior : MonoBehaviour
{
    #region Public Fields

	[SerializeField]
	Camera camera;

	[SerializeField]
	string tag;
	[SerializeField]
	float zoomAmount;
	#endregion

    #region Private Fields

	private Transform previousTarget;

	private CameraFollow trackingBehavior;
	private CameraShake cameraShake;

	private bool isLocked = false;

	#endregion

    void Start()
	{
		trackingBehavior = camera.GetComponent<CameraFollow>();
		cameraShake = camera.GetComponent<CameraShake>();
	}

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == tag && !isLocked)
		{
			isLocked = true;
			PushTarget(other.transform);
			trackingBehavior.setZoom(zoomAmount);
			//cameraShake.shakeCamera();
		}
	}

    void OnTriggerExit2D(Collider2D other)
	{

		if (other.tag == tag && isLocked)
		{
			isLocked = false;
			PopTarget();
			trackingBehavior.setZoom(trackingBehavior.OriginalZoomFactor);
		}
	}

    private void PushTarget(Transform newTarget)
	{
		previousTarget = trackingBehavior.TrackingTarget;
		trackingBehavior.TrackingTarget = newTarget;
	}

    private void PopTarget()
	{
		trackingBehavior.TrackingTarget = previousTarget;
	}
}