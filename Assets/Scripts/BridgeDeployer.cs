using UnityEngine;

public class BridgeDeployer : MonoBehaviour {

	[SerializeField] private float distance;
	[SerializeField] private float interpolation;
	[SerializeField] private float checkRange = 1;
	[SerializeField] private Transform bridge;
	[SerializeField] Transform deployPosition;
	[SerializeField] bool customPositioning;
	[SerializeField] Transform retractPosition;

	bool moving;
	bool deploying;
	bool retracting;

	float dis;

	private void Update()
	{
		if (deploying)
		{
			dis = Vector3.Distance(bridge.position, deployPosition.position);
			if (dis > checkRange)
			{
				moving = true;
			}
			else
			{
				moving = false;
				deploying = false;
			}

			if (moving)
			{
				bridge.position = Vector3.Lerp(bridge.position, deployPosition.position, interpolation * Time.deltaTime);
			}
		}

		if (retracting)
		{
			if (!customPositioning)
			{
				dis = Vector3.Distance(bridge.position, transform.position);
			}
			else
			{
				dis = Vector3.Distance(bridge.position, retractPosition.position);
			}
			if (dis > checkRange)
			{
				moving = true;
			}
			else
			{
				moving = false;
				retracting = false;
			}

			if (moving)
			{
				if (!customPositioning)
				{
					bridge.position = Vector3.Lerp(bridge.position, transform.position, interpolation * Time.deltaTime);
				}
				else
				{
					bridge.position = Vector3.Lerp(bridge.position, retractPosition.position, interpolation * Time.deltaTime);
				}
			}
		}
	}

	public void DeployBridge()
	{
		deploying = true;
		retracting = false;
	}

	public void RetractBridge()
	{
		retracting = true;
		deploying = false;
	}
}
