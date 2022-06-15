using UnityEngine;

public class Robot : MonoBehaviour
{
	[SerializeField] SignalLight movementLight;
	[SerializeField] SignalLight laserLight;

	[HideInInspector] public MovementBehavior movementBehaviour = MovementBehavior.UNDEFINED;
	[HideInInspector] public LaserBehaviour laserBehaviour = LaserBehaviour.OFF;

	public void SetMovementIsAutomatic()
	{
		movementBehaviour = MovementBehavior.AUTOMATIC;
		movementLight.SignalWithColorColor(RobotMovement.COLOR_AUTO_MOV);
	}

	public void SetMovementIsManual()
	{
		movementBehaviour = MovementBehavior.MANUAL;
		movementLight.SignalWithColorColor(RobotMovement.COLOR_MANUAL_MOV);
	}

	public void SetLaserOn()
	{
		laserBehaviour = LaserBehaviour.ON;
		laserLight.SignalWithColorColor(Color.red);
	}

	public void SetLaserOff()
	{
		laserBehaviour = LaserBehaviour.OFF;
		laserLight.TurnSignalOff();
	}
}

public enum LaserBehaviour
{
	OFF,
	ON
}

public enum MovementBehavior
{
	UNDEFINED,
	AUTOMATIC,
	MANUAL
}