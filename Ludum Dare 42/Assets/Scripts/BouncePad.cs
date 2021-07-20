using UnityEngine;

public class BouncePad : MonoBehaviour {

	[SerializeField] Vector3 bounceForce;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") || other.CompareTag("Crate"))
		{
			other.transform.GetComponent<Rigidbody>().AddForce(bounceForce);
		}
	}
}
