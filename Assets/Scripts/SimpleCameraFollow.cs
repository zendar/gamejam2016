using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour{
	public Vector3 offset;
	public float smoothTime = 0.3F;
    public Vector3 velocity = Vector3.zero;

	public static Transform target;

	void FixedUpdate(){
		Vector3 targetPos = target.position;
		Vector3 smooth = Vector3.SmoothDamp(transform.position, targetPos+offset, ref velocity, smoothTime);
		transform.position = new Vector3(smooth.x, smooth.y, transform.position.z);
	}
}