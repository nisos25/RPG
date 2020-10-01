using UnityEngine;

public class EnemyController : MonoBehaviour
{
	private GameEventListener gameEvent;

	[SerializeField] private int health = 100;

	private void Awake()
	{
		gameEvent = GetComponent<GameEventListener>();
	}

	public void DecreaseHealth(int amount)
	{
		health -= amount;

		if (health <= 0)
		{
			Dead();
		}
	}

	public void Dead()
	{
		Debug.Log("Dead!!");
		Destroy(GetComponent<Interactable>());
	}
}
