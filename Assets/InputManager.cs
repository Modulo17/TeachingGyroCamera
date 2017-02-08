using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class InputManager : MonoBehaviour {


	public	Button	GravityButton;  //Link in inspector
    public  Text 	InputText;      //Link in Inspector

    public static  InputManager IM;

    GameObject mSelected;       //The currently Selected Object

	Vector2 	mGravity=new Vector2(0f,-9.8f);

    //Create a Input Manager Singleton
	void Awake () {
        if(IM==null) {
            IM = this;
            DontDestroyOnLoad(IM.gameObject);       //Keep it around between loads
            Input.simulateMouseWithTouches = true;      //Needs to be set to emulate mouse with touch
			if (SystemInfo.supportsGyroscope) {
				Input.gyro.enabled = true;
			}
        } else if(IM!=this) {       //Don't allow duplicates
            Destroy(gameObject);
        }	
	}
	
	// Update is called once per physics frame
	void Update () {
        GetInput();
		float	tAngle=Gyro ();
		Physics2D.gravity = mGravity.Rotate (tAngle);
	}

    void GetInput() {           //Handles input
        InputText.text = "";        //Clear Text
        if(Input.GetMouseButtonDown(0)) {       //If mouse button down, see if  Ray Hit an object
            Ray tRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D tHit = Physics2D.Raycast(tRay.origin,tRay.direction);
            if(tHit.collider!=null)     {
                mSelected = tHit.collider.gameObject;       //Keep a reference to the object
                SelectGO(mSelected, true);              //Mark it selected
            }
        }
        if (Input.GetMouseButtonUp(0)) {            //If finger gone deselect
            if(mSelected!=null) {
                SelectGO(mSelected, false);
                mSelected = null;
            }
        }
        if (mSelected!=null) {      //While Selected move it
			Control	tControl=mSelected.GetComponent<Control>();
			if (tControl != null) {
				tControl.MoveTo((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
			}
        }
    }

    void    SelectGO(GameObject vGO,bool vSelect) {         //Select GameObject if it has a selection script
        Select tSelect = vGO.GetComponent<Select>();
        if (tSelect != null) {
            tSelect.Selected = vSelect;
        }
    }

	float	Gyro() {							//Get real gyro or fake it
		if (SystemInfo.supportsGyroscope) {
			Vector3	tVector = Input.gyro.gravity;
			float tAngle = Mathf.Atan2 (tVector.x, -tVector.y) * Mathf.Rad2Deg;		//Fix it so 0 is up
			InputText.text += string.Format ("{0:f2} {1:f2}", tVector, tAngle);
			GravityButton.interactable = false;
			return	tAngle;
		} else {		//Fake it with Gravity button
			float	tAngle=GravityButton.GetComponent<ShowGravity> ().Angle;
			GravityButton.interactable = true;
			return	tAngle;
		}
	}
}
