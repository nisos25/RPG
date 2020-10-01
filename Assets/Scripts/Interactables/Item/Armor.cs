using UnityEngine;

/// <summary>
/// Type of armor for items that could be equipped.
/// </summary>
public enum TypeOfArmor { Helmet, Breastplate, Gauntlet, Cuisse, Weapon, Shield }

[CreateAssetMenu]
public class Armor : Item
{
	[SerializeField] private TypeOfArmor typeOfArmor;
	[SerializeField] private int armorModifier;
	[SerializeField] private int damageModifier;


	#region Properties

	public TypeOfArmor ArmorType
	{
		get { return typeOfArmor; }
		set { typeOfArmor = value; }
	}

	public int ArmorModifier
	{
		get { return armorModifier; }
		set { armorModifier = value; }
	}

	public int DamageModifier
	{
		get { return damageModifier; }
		set { damageModifier = value; }
	}

	#endregion


	public override void Use()
	{



	}


}