using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
	[SerializeField] private string itemName;
	[TextArea]
	[SerializeField] private string description;
	[SerializeField] private Sprite icon;

	public string ItemName
	{
		get { return itemName; }
	}

	public string Description
	{
		get { return description; }
	}

	public Sprite Icon
	{
		get { return icon; }
	}

	/// <summary>
	/// Called when the player tries to use an item. Should be override by
	/// every different item.
	/// </summary>
	public virtual void Use()
	{

	}
}