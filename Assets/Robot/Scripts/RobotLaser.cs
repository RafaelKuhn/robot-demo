using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Robot))]
public class RobotLaser : MonoBehaviour
{
	Robot robot;

	void Awake()
	{
		robot = GetComponent<Robot>();
	}

	void Start()
	{
		robot.SetLaserOn();
	}

	void OnDestroy()
	{
		robot.SetLaserOff();
	}
	

	int lastHitObjectID = 0;
	Wall lastHitWall = null;

	void Update()
	{
		bool isHittingSomething = Physics.Raycast(transform.position, transform.forward, out RaycastHit hitData);
		if (!isHittingSomething)
		{
			if (lastHitWall != null)
			{
				lastHitWall.ResetMaterial();
			}

			lastHitObjectID = 0;
			return;
		}
		

		int hitObjectID = hitData.collider.gameObject.GetInstanceID();
		if (hitObjectID != lastHitObjectID)
		{
			lastHitWall = hitData.collider.GetComponent<Wall>();
			
			if (lastHitWall == null)
			{
				return;
			}

			lastHitWall.ApplyLaserMaterial();
			lastHitObjectID = hitObjectID;
		}
	}
}
