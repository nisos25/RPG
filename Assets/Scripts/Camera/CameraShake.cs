using UnityEngine;

public class CameraShake : MonoBehaviour
{
	/// <summary>
	/// Transform of the camera to shake. Grabs the gameObject's transform
	/// if null.
	/// </summary>
	private Transform cameraTransform;
	private Vector3 originalPosition;
	private float shakeDurationLeft;

	/// <summary>
	/// How long the object should shake for.
	/// </summary>
	[SerializeField] private float shakeDuration;

	/// <summary>
	/// Amplitude of the shake. A larger value shakes the camera harder.
	/// </summary>
	[SerializeField] private float shakeAmount = 0.7f;

	private void Awake()
	{
		cameraTransform = GetComponent<Transform>();
	}

	private void OnEnable()
	{
		shakeDurationLeft = shakeDuration;
	}

	public void Update()
	{
		if (shakeDurationLeft > 0)
		{
			originalPosition = cameraTransform.localPosition;

			cameraTransform.localPosition = originalPosition + Random.insideUnitSphere * shakeAmount;

			shakeDurationLeft -= Time.deltaTime;
		}
		else
		{
			shakeDurationLeft = 0f;
			cameraTransform.localPosition = originalPosition;
			enabled = false;
		}
	}
}