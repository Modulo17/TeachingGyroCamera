using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour {


    SpriteRenderer mSR;         //Get SpriteRenderer
    bool mSelected;             //Is Object Selected

	Rigidbody2D		mRB;

    Color mSelectedColour;      //Colour to use for Selected state
    Color mColour;              //Normal Colour

    public bool Selected {      //Set/Get Object selected state
        set {
            mSelected = value;
            mSR.color = (mSelected) ? mSelectedColour : mColour;
			mRB.gravityScale = (mSelected) ? 0f : 1f;
        }
        get {
            return mSelected;
        }
    }


	// Use this for initialization
	void Start () {
		mRB = GetComponent<Rigidbody2D> ();
        mSR = GetComponent<SpriteRenderer>();       //Get Sprite render Reference
        mColour = mSR.color;        //Keep Default colour
        mSelectedColour = new Color(mColour.r, mColour.g, mColour.b, mColour.a * 0.7f); //New Colour
	}
}
