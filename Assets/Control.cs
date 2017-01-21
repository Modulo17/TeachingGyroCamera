using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

    Vector3         mDefaultPosition;         //Used to reset object to starting position
    Quaternion      mDefaultRotation;

    void Start () {
        mDefaultPosition = transform.position;              //Remember starting position and rotation
        mDefaultRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public  void    Reset() {           //Reset position
        transform.position = mDefaultPosition;
        transform.rotation = mDefaultRotation;
    }
}
