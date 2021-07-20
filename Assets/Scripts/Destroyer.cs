using UnityEngine;

public class Destroyer : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			other.GetComponent<PlayerController>().Die();
		}
		if (other.CompareTag("Crate"))
		{
			Destroy(other.gameObject);
		}
	}
}
