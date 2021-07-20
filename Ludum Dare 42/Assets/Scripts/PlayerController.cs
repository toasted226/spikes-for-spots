using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	[SerializeField] private float moveSpeed;
	[SerializeField] private GameObject onDeath;
	[SerializeField] private string levelToLoad;

	private Rigidbody rb;
	private Animation anim;
	private float x;
	private float y;
	bool dead = false;
	bool grounded = true;
	bool usingBouncePad;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		anim = GetComponentInChildren<Animation>();
	}

	void Update ()
	{
		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");
		Vector2 input = new Vector2(x, y);
		Vector2 inputDir = input.normalized;

		transform.eulerAngles = Vector3.up * Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;

		if (grounded)
		{
			if (Mathf.Abs(x) > 0 || Mathf.Abs(y) > 0)
			{
				anim.Play("Character_Walk");
			}
			else
			{
				anim.Stop();
			}
		}

		if(dead)
		{
			if (Input.GetMouseButtonDown(0))
			{
				SceneManager.LoadScene(levelToLoad);
			}
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				SceneManager.LoadScene("Main Menu");
			}
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(levelToLoad);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.name == "L_Wall" || collision.transform.name == "R_Wall")
		{
			Die();
		}
	}

	private void FixedUpdate()
	{
		if (grounded)
		{
			rb.MovePosition(transform.position + new Vector3(x, 0, y) * moveSpeed * Time.fixedDeltaTime);
		}
	}

	public void Die()
	{
		onDeath.SetActive(true);
		transform.GetChild(0).gameObject.SetActive(false);
		Camera.main.transform.GetComponent<CameraFollow>().enabled = false;
		dead = true;
	}

	private void OnCollisionStay()
	{
		grounded = true;
		usingBouncePad = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Bounce Pad"))
		{
			usingBouncePad = true;
			grounded = false;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Bounce Pad"))
		{
			usingBouncePad = true;
			grounded = false;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Bounce Pad"))
		{
			usingBouncePad = true;
			grounded = false;
		}
	}

	private void OnCollisionExit()
	{
		if (usingBouncePad)
		{
			grounded = false;
		}
	}
}
