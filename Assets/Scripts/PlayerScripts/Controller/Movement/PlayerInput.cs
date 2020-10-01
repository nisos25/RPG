using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
	private PlayerController playerController;

	[SerializeField] private LayerMask whatCouldBeShoot;

	private void Awake()
	{
		playerController = GetComponent<PlayerController>();
	}

	private void Update()
	{
		if (!Input.GetMouseButtonDown(0)) return;
		RaycastHit hit;

		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, whatCouldBeShoot))
		{
			playerController.Clicked(hit);
		}
	}
}