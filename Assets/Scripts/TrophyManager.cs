using UnityEngine;

public class TrophyManager : MonoBehaviour {

	public void chapter1complete_Unlock()
	{
		GameJolt.API.Trophies.Unlock(101097, (bool success) => 
		{
			if (!success)
			{
				Debug.Log("Something went wrong...");
			}
		});
	}
}
