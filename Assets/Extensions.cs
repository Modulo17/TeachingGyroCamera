using UnityEngine;
using System.Collections;



public static class Vector2Extension {		//Add rotate to Vector2

	public static Vector2 Rotate(this Vector2 vVector, float vDegrees) {
		float vSin = Mathf.Sin(vDegrees * Mathf.Deg2Rad);
		float vCos = Mathf.Cos(vDegrees * Mathf.Deg2Rad);

		float tx = vVector.x;
		float ty = vVector.y;
		vVector.x = (vCos * tx) - (vSin * ty);
		vVector.y = (vSin * tx) + (vCos * ty);
		return vVector;
	}
}
