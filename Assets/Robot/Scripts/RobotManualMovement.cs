using UnityEngine;

public class RobotManualMovement : RobotMovement
{
	[Range(0.1f, 16.0f)] [SerializeField] float speed = 8.0f;
	[Range(Consts.TAU / 16f, Consts.TAU / 2f)] [SerializeField] float rotationAngle = Consts.TAU / 4f;

	Robot robot;

	void Awake()
	{
		robot = GetComponent<Robot>();
	}

	void Start()
	{
		robot.SetMovementIsManual();
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
		{
			MoveForwards();

			if (Input.GetKey(KeyCode.D))
			{
				transform.Rotate(new Vector3(0, rotationAngle, 0), Space.Self);
			}

			if (Input.GetKey(KeyCode.A))
			{
				transform.Rotate(new Vector3(0, - rotationAngle, 0), Space.Self);
			}
		}

		if (Input.GetKey(KeyCode.S))
		{
			MoveBackwards();
		}

	}

	private void MoveForwards()
	{
		transform.localPosition += transform.forward * Time.deltaTime * speed;
	}

	private void MoveBackwards()
	{
		transform.localPosition -= transform.forward * Time.deltaTime * speed;
	}
}

