using UnityEngine;

public class CrateDispenser : MonoBehaviour {

	[SerializeField] private GameObject crate;
	[SerializeField] private float delay = 1f;

	bool canDispense = true;

	public void DispenseCrate()
	{
		if (canDispense)
		{
			Instantiate(crate, transform.position, Quaternion.Euler(0, 0, 0));
			canDispense = false;
			Invoke("RunDelay", delay);
		}
	}

	void RunDelay()
	{
		canDispense = true;
	}
}
