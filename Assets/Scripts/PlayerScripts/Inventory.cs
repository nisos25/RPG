using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
	[SerializeField] private int inventorySpace;
	[SerializeField] private List<Item> items = new List<Item>();

	public bool AddItem(Item item)
	{
		if (items.Count < inventorySpace)
		{
			items.Add(item);
			return true;
		}

		Debug.Log("Not enough room");
		return false;
	}

	public void RemoveItem(Item item)
	{
		items.Remove(item);
	}

}
