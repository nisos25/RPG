using System;
using UnityEngine;

public class Pickup : Interactable
{
	[SerializeField] private Item item;

	public Item PickupItem => item;


	/// <summary>
	/// How this object behaves when a player is interacting with it
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	public override T Interacting<T>()
	{
		BePickedUp();


		return (T)Convert.ChangeType(PickupItem, typeof(T));
	}

	private void BePickedUp()
	{
		Debug.Log("A rare " + PickupItem.ItemName + " was found");
		Destroy(gameObject);
	}
}