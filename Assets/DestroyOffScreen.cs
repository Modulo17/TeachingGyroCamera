using UnityEngine;
using System.Collections;

public class DestroyOffScreen : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		Vector2	mScreenPosition = Camera.main.WorldToViewportPoint (transform.position);
		if (mScreenPosition.x < 0f || mScreenPosition.x > 1f || mScreenPosition.y < 0f || mScreenPosition.y > 1f) {
			Destroy(gameObject);
		}
	}
}
