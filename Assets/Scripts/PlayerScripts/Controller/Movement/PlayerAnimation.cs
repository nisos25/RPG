using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	private Animator animator;

	[SerializeField] private PlayerStates playerStates;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		animator.SetFloat("Speed", playerStates.Velocity);
		animator.SetBool("Attacking", playerStates.Attacking);
	}

	/// <summary>
	/// Called when attack finish.
	/// called by animator event.
	/// </summary>
	public void AttackFinished()
	{
		playerStates.Attacking = false;
	}

	/// <summary>
	/// Called when player attack(moment when sword cut).
	/// Called by animator events.
	/// </summary>
	private void Attacking()
	{
		playerStates.AttackingEvent();
	}
}