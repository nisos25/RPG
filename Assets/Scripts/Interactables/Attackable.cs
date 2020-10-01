using System;

public class Attackable : Interactable
{
	private EnemyController enemyController;


	private void Awake()
	{
		enemyController = GetComponent<EnemyController>();
	}

	/// <summary>
	/// Calls EnemyControllerMethod to decrease health.
	/// </summary>
	/// <param name="lifeTaken">Amount of life to decrease.</param>
	/// <returns>This attackable.</returns>
	public Attackable BeingAttacked(int lifeTaken)
	{
		enemyController.DecreaseHealth(lifeTaken);

		return Interacting<Attackable>();
	}

	public override T Interacting<T>()
	{
		return (T)Convert.ChangeType(this, typeof(T));
	}
}