using UnityEngine;

[CreateAssetMenu]
public class IntReference : ScriptableObject
{
	[SerializeField] private int reference;

	public int Reference
	{
		get { return reference; }
		set { reference = value; }
	}
}

