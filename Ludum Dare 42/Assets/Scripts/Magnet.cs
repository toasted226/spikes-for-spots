using UnityEngine;

public class Magnet : MonoBehaviour {

	[SerializeField] private float radius;
	[SerializeField] private float forceMultiplier;
	[SerializeField] private bool attracting = false;
	[SerializeField] private LayerMask magnetisedLayer;
	[SerializeField] private GameObject detail;

	public void SetAttract(bool attract)
	{
		attracting = attract;
	}

	private void Update()
	{
		if (attracting)
		{
			detail.SetActive(true);

			Collider[] magnetisables = Physics.OverlapSphere(transform.position, radius, magnetisedLayer);
			foreach (Collider magnetised in magnetisables)
			{
				Vector3 dir = transform.position - magnetised.transform.position;
				float dis = Vector3.Distance(transform.position, magnetised.transform.position);
				magnetised.GetComponent<Rigidbody>().AddForce((dir / dis) * forceMultiplier);
			}
		}
		else
		{
			detail.SetActive(false);
		}
	}
}
