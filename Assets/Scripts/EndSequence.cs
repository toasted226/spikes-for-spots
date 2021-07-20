using UnityEngine;

public class EndSequence : MonoBehaviour
{
	public GameObject endsequence;

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			endsequence.SetActive(true);
			Camera.main.transform.GetComponent<CameraFollow>().offset = new Vector3(0, 10f, 0);
		}
	}
}
