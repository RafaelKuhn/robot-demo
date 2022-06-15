using System.Linq;
using UnityEngine;

public class RobotsMovementController : MonoBehaviour
{
	public void ToggleActiveRobotsMovement()
	{
		var activeRobots = FindObjectsOfType<Robot>().Where(robot => robot.isActiveAndEnabled);

		foreach (Robot robot in activeRobots)
		{
			var robotMovement = robot.GetComponent<RobotMovement>();
			bool robotHasNoMovement = robotMovement == null;
			if (robotHasNoMovement) return;

			ChangeMovementToAutoIfManual(robot, robotMovement);
			ChangeMovementToManualIfAuto(robot, robotMovement);
		}
	}

	private void ChangeMovementToManualIfAuto(Robot robot, RobotMovement movement)
	{
		bool robotMovementIsNotAuto = movement.GetType() != typeof(RobotAutoMovement);
		if (robotMovementIsNotAuto) return;
		
		DestroyImmediate(movement);
		robot.gameObject.AddComponent<RobotManualMovement>();
		print($"movement on robot {robot.name} changed to manual!");
	}

	private void ChangeMovementToAutoIfManual(Robot robot, RobotMovement movement)
	{
		bool robotMovementIsNotManual = movement.GetType() != typeof(RobotManualMovement);
		if (robotMovementIsNotManual) return;
		
		DestroyImmediate(movement);
		robot.gameObject.AddComponent<RobotAutoMovement>();
		print($"movement on robot {robot.name} changed to auto!");
	}
}
