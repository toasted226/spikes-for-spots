using UnityEngine;

public class Portal : MonoBehaviour {

	[SerializeField] private Transform teleportPosition;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") || other.CompareTag("Crate"))
		{
			other.transform.position = teleportPosition.position;
		}
	}
}
