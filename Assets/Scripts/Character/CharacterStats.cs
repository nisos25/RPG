using UnityEngine;

public class CharacterStats : MonoBehaviour
{
	[SerializeField] private int maximumHealth;

	public int CurrentHealth { get; private set; }

	private void Start()
	{
		if (maximumHealth == 0)
		{
			SetCurrentHealth(100);
		}
	}

	public void SetCurrentHealth(int characterHealth)
	{
		maximumHealth = characterHealth;

		CurrentHealth = maximumHealth;
	}

	public void TakeDamage(int damage)
	{
		CurrentHealth -= damage;

		if (CurrentHealth <= 0)
		{
			Die();
		}
	}

	public virtual void Die()
	{

	}
}