using UnityEngine;
public class CameraFollow : MonoBehaviour
{

	[SerializeField] private Transform target;
	public Vector3 offset;
	[SerializeField] private float interpolation;

	private void Update()
	{
		Vector3 movementPos = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, movementPos, interpolation);

		//transform.LookAt(target);
	}
}