using UnityEngine;

public class Interactable : MonoBehaviour
{
	[SerializeField] private float radius;
	[SerializeField] private Transform interactionTransform;

	#region Properties

	/// <summary>
	/// Radius where player is going to be able to interact.
	/// </summary>
	public float Radius => radius;

	public Transform InteractionTransform => interactionTransform;

	#endregion

	/// <summary>
	/// Should be override and called when the player is interacting with any object.
	/// </summary>
	/// <typeparam name="T">Object with which the player is interacting.</typeparam>
	/// <returns></returns>
	public virtual T Interacting<T>() where T : new()
	{
		return new T();
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}
}