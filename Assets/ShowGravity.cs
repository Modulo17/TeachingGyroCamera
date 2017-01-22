using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowGravity : MonoBehaviour {

	Image	mIndicator;		//Arrow Sprite

	float	mAngle;

	// Use this for initialization
	void Start () {
		mIndicator = GetComponent<Image> ();	//Get Arrow
	}
	
	// Update is called once per physics frame
	void FixedUpdate () {
		mAngle = Mathf.Atan2 (Physics2D.gravity.x, -Physics2D.gravity.y)*Mathf.Rad2Deg;
		mIndicator.transform.rotation = Quaternion.Euler (0, 0, mAngle+180f);	//As arrow default is up, offset rotate down
	}

	public	void Click(float vDelta) {		//On Click change gravity
		Angle += vDelta;
	}

	public	float	Angle {		//Get and set angle of gravity vector
		get {
			return	mAngle;
		}

		set {
			mAngle = value;
			Physics2D.gravity.Rotate (mAngle);
		}
	}
}
