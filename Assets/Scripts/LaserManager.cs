using UnityEngine;
using UnityEngine.Events;

public class LaserManager : MonoBehaviour {

	[SerializeField] private float range = 100;

	public UnityEvent OnTriggerEnter;
	public UnityEvent OnTriggerExit;
	public string collisionTag;
	public bool isTriggered;
	[HideInInspector]public bool active;

	private LineRenderer lr;

	bool called = false;

	private void Start()
	{
		lr = GetComponent<LineRenderer>();
	}

	private void Update()
	{
		if (!isTriggered || active)
		{
			RaycastHit laser;
			if (Physics.Raycast(transform.position, transform.forward, out laser, range))
			{
				if (laser.collider.tag == "Player")
				{
					laser.collider.GetComponent<PlayerController>().Die();
				}

				if (laser.collider.tag == collisionTag)
				{
					if (!called)
					{
						OnTriggerEnter.Invoke();
						called = true;
					}
				}
				else
				{
					if (called)
					{
						OnTriggerExit.Invoke();
						called = false;
					}
				}
			}

			lr.SetPosition(0, transform.position);
			lr.SetPosition(1, laser.point);
		}
	}

	public void Activate()
	{
		active = true;
		lr.enabled = true;
	}

	public void Deactivate()
	{
		active = false;
		lr.enabled = false;
	}
}
