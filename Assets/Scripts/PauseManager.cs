using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

	[SerializeField]private GameObject pauseMenuObject;
	bool paused;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!paused)
				Pause();
			else
				Resume();
		}
	}

	public void Pause()
	{
		Time.timeScale = 0f;
		pauseMenuObject.SetActive(true);
		paused = true;
	}

	public void Resume()
	{
		Time.timeScale = 1f;
		pauseMenuObject.SetActive(false);
		paused = false;
	}

	public void QuitToMenu()
	{
		SceneManager.LoadScene("Main Menu");
	}
}
