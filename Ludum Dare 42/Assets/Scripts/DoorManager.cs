using UnityEngine;

public class DoorManager : MonoBehaviour {

	[SerializeField] private bool isPredoor = false;
	private Animation anim;

	private void Start()
	{
		anim = GetComponent<Animation>();
	}

	public void OpenDoor()
	{
		if (!isPredoor)
		{
			anim.Play("Door_Open");
		}
		else
		{
			anim.Play("Predoor_Open");
		}
	}

	public void CloseDoor()
	{
		if (!isPredoor)
		{
			anim.Play("Door_Close");
		}
		else
		{
			anim.Play("Predoor_Close");
		}
	}
}
