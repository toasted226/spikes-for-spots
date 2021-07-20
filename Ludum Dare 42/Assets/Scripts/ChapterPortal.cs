using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterPortal : MonoBehaviour {

	[SerializeField] private string nextChapter;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			SceneManager.LoadScene(nextChapter);
		}
	}
}
