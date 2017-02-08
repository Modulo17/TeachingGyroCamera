using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowGravity : MonoBehaviour {

	Image	mIndicator;		//Arrow Sprite

	float	mAngle;         //Angle of Device
    Text mText;

	// Use this for initialization
	void Start () {
		mIndicator = GetComponent<Image> ();	//Get Arrow
        if(SystemInfo.supportsGyroscope) {
            GetComponentInChildren<Text>().text = "Gyro OK";
        } else {
            GetComponentInChildren<Text>().text = "No Gyro";
        }
    }
	
	// Update is called once per physics frame
	void FixedUpdate () {
		mAngle = Mathf.Atan2 (Physics2D.gravity.x, -Physics2D.gravity.y)*Mathf.Rad2Deg; //Progably safer changing gravity on physics update
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
