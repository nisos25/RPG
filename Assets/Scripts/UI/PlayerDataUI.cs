using UnityEngine;
using UnityEngine.UI;

public class PlayerDataUI : MonoBehaviour
{
	/// <summary>
	/// Reference to the health and mana data
	/// </summary>
	[SerializeField] private IntReference healthData;
	[SerializeField] private IntReference manaData;
	[SerializeField] private Image healthBar;
	[SerializeField] private Image manaBar;

	private float maximumHealth;
	private float maximumMana;

	private void Awake()
	{
		maximumHealth = healthData.Reference;
		maximumMana = manaData.Reference;
	}

	private void Update()
	{
		healthBar.fillAmount = healthData.Reference / maximumHealth;
		manaBar.fillAmount = manaData.Reference / maximumMana;
	}
}