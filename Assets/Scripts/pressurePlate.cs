using UnityEngine;
using UnityEngine.Events;

public class pressurePlate : MonoBehaviour {

	[SerializeField] private GameObject activePlate;
	[SerializeField] private GameObject inactivePlate;
	[Header("Events")]
	public UnityEvent OnActivate;
	public UnityEvent OnDeactivate;

	bool canTrigger = true;
	bool registering = true;

	public void DeactivateRegistration()
	{
		registering = false;
		OnDeactivate.Invoke();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (registering)
		{
			if (other.transform.tag == "Crate")
			{
				OnActivate.Invoke();
				activePlate.SetActive(true);
				inactivePlate.SetActive(false);
				canTrigger = false;
			}
			if (other.transform.tag == "Player")
			{
				if (canTrigger)
				{
					OnActivate.Invoke();
					activePlate.SetActive(true);
					inactivePlate.SetActive(false);
				}
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (registering)
		{
			if (other.transform.tag == "Player")
			{
				if (canTrigger)
				{
					inactivePlate.SetActive(true);
					activePlate.SetActive(false);
					OnDeactivate.Invoke();
				}
			}
			if (other.transform.tag == "Crate")
			{
				inactivePlate.SetActive(true);
				activePlate.SetActive(false);
				OnDeactivate.Invoke();
				canTrigger = true;
			}
		}
	}

	public void Activate()
	{
		OnActivate.Invoke();
		activePlate.SetActive(true);
		inactivePlate.SetActive(false);
	}

	public void Deactivate()
	{
		inactivePlate.SetActive(true);
		activePlate.SetActive(false);
		OnDeactivate.Invoke();
	}
}
