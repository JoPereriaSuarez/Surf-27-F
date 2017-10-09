using UnityEngine;
using System.Collections;

public static class VectorToAngle
{
	public static float AngleInRadians(Vector2 v_1, Vector2 v_2)
	{
		return Mathf.Atan2(v_2.y-v_1.y, v_2.x - v_1.x);
	}
	public static float AngleInDegrees(Vector2 v_1, Vector2 v_2)
	{
		return AngleInRadians(v_1, v_2) * (180 / Mathf.PI);
	}
}

