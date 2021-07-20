using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	[SerializeField] private int currentChapter;

	public void Play()
	{
		SceneManager.LoadScene("Chapter " + currentChapter);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
