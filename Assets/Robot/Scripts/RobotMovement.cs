using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Robot))]
public abstract class RobotMovement : MonoBehaviour
{
	public static Color32 COLOR_AUTO_MOV = new Color32(255, 128, 0, 255);
	public static Color32 COLOR_MANUAL_MOV = new Color32(0, 255, 0, 255);
}