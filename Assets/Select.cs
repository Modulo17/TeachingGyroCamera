using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour {

	AudioSource[]	mAud;

    SpriteRenderer mSR;         //Get SpriteRenderer
    bool mSelected;             //Is Object Selected

	Rigidbody2D		mRB;

    Color mSelectedColour;      //Colour to use for Selected state
    Color mColour;              //Normal Colour

    public bool Selected {      //Set/Get Object selected state
        set {
            mSelected = value;
			if (mSelected) {
				#if UNITY_WEBGL
				#else
				if (SystemInfo.supportsVibration) {		//Vibrate on select
					Handheld.Vibrate ();
				}
				#endif
				mAud[0].Play ();
				mSR.color = mSelectedColour;		//Show selected colour
				mRB.gravityScale = 0f;				//Allow move without gravity
			} else {
				mSR.color = mColour;
				mRB.gravityScale = 1f;
			}
        }
        get {
            return mSelected;
        }
    }


	// Use this for initialization
	void Start () {
		mRB = GetComponent<Rigidbody2D> ();
        mSR = GetComponent<SpriteRenderer>();       //Get Sprite render Reference
		mAud = GetComponents<AudioSource>();

        mColour = mSR.color;        //Keep Default colour
        mSelectedColour = new Color(mColour.r, mColour.g, mColour.b, mColour.a * 0.7f); //New Colour
	}
}
