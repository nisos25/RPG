using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
	private NavMeshAgent agent;
	private Interactable objInteractable;
	private PlayerInteract playerInteract;

	[SerializeField] private PlayerStates playerStates;

	private void Awake()
	{
		playerInteract = GetComponent<PlayerInteract>();
		agent = GetComponent<NavMeshAgent>();
		//Prevent weird error.
		playerStates.Attacking = false;
	}

	private void Update()
	{
		playerStates.Velocity = agent.velocity.magnitude;

		if (objInteractable != null)
			FaceTarget();
	}

	/// <summary>
	/// Called when player hit a new location, realize if player could interact or simply reach the point.
	/// </summary>
	/// <param name="hitLocation">Location where player is trying to move.</param>
	public void Clicked(RaycastHit hitLocation)
	{
		if (playerStates.Attacking)
			return;

		objInteractable = hitLocation.collider.gameObject.GetComponent<Interactable>();

		if (objInteractable != null)
		{
			StartInteraction();
			return;
		}

		playerStates.Attacking = false;
		Move(hitLocation.point);
	}

	private void Move(Vector3 movementPoint)
	{
		agent.SetDestination(movementPoint);
	}

	#region Interaction

	/// <summary>
	/// Moves towards the object to interact.
	/// </summary>
	private void StartInteraction()
	{
		agent.stoppingDistance = objInteractable.Radius * .9f;

		Move(objInteractable.InteractionTransform.position);

		StartCoroutine(CheckDistanceToInteractable());
	}

	/// <summary>
	/// Reset the stopping distance and starts the interaction once the
	/// player reach the destination(That's what both if's check).
	/// </summary>
	/// <returns></returns>
	private IEnumerator CheckDistanceToInteractable()
	{
		while (objInteractable != null)
		{
			bool distance = (agent.destination - agent.transform.position).sqrMagnitude <=
							agent.stoppingDistance * agent.stoppingDistance;
			if (distance)
			{
				if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
				{
					playerInteract.Interact(objInteractable);
					agent.path = new NavMeshPath();
					agent.stoppingDistance = 0f;
					yield break;
				}
			}

			Move(objInteractable.InteractionTransform.position);

			yield return null;
		}

		agent.stoppingDistance = 0f;
	}

	/// <summary>
	/// Face target if player is trying to interact.
	/// </summary>
	private void FaceTarget()
	{
		Vector3 direction = (objInteractable.gameObject.transform.position - transform.position).normalized;

		Quaternion rotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));

		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 6f);
	}


	#endregion
}