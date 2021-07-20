using System.Collections;
using UnityEngine;

public class LevelOptimisation : MonoBehaviour {

	public GameObject[] levels;
	public int currentLevel;
	public int nextLevel;
	public int previousLevel;
	[Space]
	[SerializeField] private float step = 1f;

	private void Start()
	{
		StartCoroutine(StepOptimisation());
	}

	private void Update()
	{
		if (currentLevel > 0)
			previousLevel = currentLevel - 1;
		else
			previousLevel = currentLevel;

		if (currentLevel != levels.Length)
			nextLevel = currentLevel + 1;
		else
			nextLevel = 0;
	}

	IEnumerator StepOptimisation()
	{
		while (true)
		{
			UnloadReloadLevels();
			yield return new WaitForSeconds(step);
		}
	}

	public void UnloadReloadLevels()
	{
		for (int i = 0; i < levels.Length; i++)
		{
			if (currentLevel >= 0 && currentLevel <= levels.Length)
			{
				if (i < previousLevel)
					levels[i].SetActive(false);
				else
					levels[i].SetActive(true);

				if (i > nextLevel)
					levels[i].SetActive(false);
			}
		}
	}
}
