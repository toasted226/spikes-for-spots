using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinalEnd : MonoBehaviour {

	public GameObject seq;
	public GameObject end;

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			seq.SetActive(false);
			end.SetActive(true);
			StartCoroutine("EndGame");
		}
	}

	public IEnumerator EndGame()
	{
		yield return new WaitForSeconds(10f);
		SceneManager.LoadScene("Main Menu");
	}
}
