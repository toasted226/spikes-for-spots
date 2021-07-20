using UnityEngine;
using UnityEngine.Events;

public class LevelInitialization : MonoBehaviour {

	public UnityEvent OnLevelInitialize;

	bool canTrigger = true;

	private void OnTriggerEnter(Collider other)
	{
		if (canTrigger)
		{
			if (other.transform.tag == "Player")
			{
				OnLevelInitialize.Invoke();
				canTrigger = false;
			}
		}
	}
}
