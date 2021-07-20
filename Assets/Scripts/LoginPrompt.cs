using UnityEngine;

public class LoginPrompt : MonoBehaviour {

	bool signedIn;
	[SerializeField] private GameObject playButton;

	private void Start()
	{
		GameJolt.UI.GameJoltUI.Instance.ShowSignIn();
	}

	private void Update()
	{
		if (GameJolt.API.GameJoltAPI.Instance.CurrentUser != null)
		{
			signedIn = true;
		}

		if(signedIn && playButton != null)
			playButton.SetActive(true);
	}
}
