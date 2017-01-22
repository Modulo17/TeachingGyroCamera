using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

    Vector3         mDefaultPosition;         //Used to reset object to starting position
    float      		mDefaultRotation;

	Rigidbody2D		mRB;

    void Start () {
		mRB = GetComponent<Rigidbody2D> ();
		mDefaultPosition = mRB.position;              //Remember starting position and rotation
		mDefaultRotation = mRB.rotation;

	}
	
    public  void    Reset() {           					//Reset position
		mRB.position = mDefaultPosition;
		mRB.rotation = mDefaultRotation;
		mRB.angularVelocity = 0f;
		mRB.velocity = Vector2.zero;
    }

	public	void	MoveTo(Vector2 vPosition) {		//Move using physics
		mRB.MovePosition (vPosition);
	}

}
