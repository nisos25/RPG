using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
	private Interactable objectInteractable;

	[SerializeField] private Inventory inventory;
	[SerializeField] private PlayerStates playerStates;

	/// <summary>
	/// Called the override method "Interacting" to interact with the object based on the type.
	/// </summary>
	public void Interact(Interactable objInteractable)
	{
		objectInteractable = objInteractable;

		//Implementation should change if cases increase(strategy pattern)
		switch (objectInteractable.GetType().ToString())
		{
			case "Pickup":
				{
					Pickup();
					break;
				}
			case "Attackable":
				{
					Attack();
					break;
				}
		}
	}

	private void Pickup()
	{
		var pickupType = objectInteractable.GetComponent<Pickup>().PickupItem.GetType();

		var interactingMethod = typeof(Pickup).GetMethod("Interacting");
		var interactingRef = interactingMethod.MakeGenericMethod(pickupType);

		if (inventory.AddItem((Item)interactingRef.Invoke(objectInteractable, null)))
		{
			Destroy(objectInteractable.gameObject);
		}

	}

	private void Attack()
	{
		if (!playerStates.Attacking)
		{
			objectInteractable.GetComponent<Attackable>().BeingAttacked(10);
			playerStates.Attacking = true;
		}
	}
}