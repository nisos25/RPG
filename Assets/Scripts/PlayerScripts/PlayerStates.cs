using UnityEngine;

[CreateAssetMenu]
public class PlayerStates : ScriptableObject
{
	[SerializeField] private float velocity;
	[SerializeField] private bool attacking;
	[SerializeField] private GameEvent attackEvent;

	public float Velocity
	{
		get { return velocity; }
		set { velocity = value; }
	}
	public bool Attacking
	{
		get { return attacking; }
		set { attacking = value; }
	}

	/// <summary>
	/// Called by animation event in PlayerAnimation.
	/// </summary>
	public void AttackingEvent()
	{
		attackEvent.Raise();
	}
}
