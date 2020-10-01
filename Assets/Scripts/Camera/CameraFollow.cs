using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	[SerializeField] private Transform target;            //Target to follow
	[SerializeField] private Vector3 offset;              //Camera Offset
	[SerializeField] private float smooth;                //How fast camera should move

	private Vector3 velocity;

	void LateUpdate()
	{
		Vector3 finalTargetPosition = target.position + offset;
		Vector3 cameraMovement = Vector3.SmoothDamp(transform.position, finalTargetPosition, ref velocity, smooth);
		transform.position = cameraMovement;
	}
}