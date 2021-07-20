using UnityEngine;

public class WallManager : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private Transform leftWall;
	[SerializeField] private Transform rightWall;

	bool moving = false;

	public void ActivateWalls()
	{
		moving = true;
	}
	public void DeactivateWalls()
	{
		moving = false;
	}

	private void Update()
	{
		if (moving)
		{
			leftWall.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
			rightWall.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.name == "L_Wall" || collision.transform.name == "R_Wall")
		{
			moving = false;
		}
	}
}
