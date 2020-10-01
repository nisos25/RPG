using System;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
	private Armor[] armor;

	private void Awake()
	{
		int count = Enum.GetValues(typeof(TypeOfArmor)).Length;

		armor = new Armor[count];
	}

	public void Equip(Armor newArmor)
	{
		int position = (int)newArmor.ArmorType;

		armor[position] = newArmor;
	}
}