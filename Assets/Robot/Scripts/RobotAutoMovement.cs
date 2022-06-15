using UnityEngine;

public class RobotAutoMovement : RobotMovement
{
	[Range(2.0f, 16.0f)] [SerializeField] float speed = 8.0f;
	[Range(1.0f, 10.0f)] [SerializeField] float amplitude = 4.0f;

	[Range(0.001f,1.0f)] [SerializeField] float howFarToLook = 0.01f;


	Vector3 startPosition;
	float localTime;

	Robot robot;

	void Awake()
	{
		robot = GetComponent<Robot>();
	}

	void OnEnable()
	{
		startPosition = transform.position;
		localTime = 0f;
	}

	void Start()
	{
		robot.SetMovementIsAutomatic();
	}

	void Update()
    {
		MoveInPath();
		LookAtFuturePositionInPath();

		PassLocalTime();
	}


	private void MoveInPath()
	{
		transform.position = GetPositionInPath(localTime);
	}

	private void LookAtFuturePositionInPath()
	{
		float futureTime = localTime + howFarToLook;
		Vector3 futurePosition = GetPositionInPath(futureTime);

		transform.LookAt(futurePosition);
	}

	private Vector3 GetPositionInPath(float time)
	{
		float sinOfTime = Mathf.Sin(time * speed / amplitude);
		float cosOfTime = Mathf.Cos(time * speed / amplitude);

		float xPosition = startPosition.x + sinOfTime * amplitude;
		float zPosition = startPosition.z + cosOfTime * sinOfTime * amplitude;

		return new Vector3(xPosition, startPosition.y, zPosition);
	}

	private void PassLocalTime()
	{
		localTime += Time.deltaTime;
	}
}
