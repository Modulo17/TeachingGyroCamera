using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class InputManager : MonoBehaviour {

    public  Text InputText;      //Link in Inspector

    static  public   InputManager IM;

    GameObject mSelected;       //The currently Selected Object
	
    //Create a Input Manager Singleton
	void Awake () {
        if(IM==null) {
            IM = this;
            DontDestroyOnLoad(IM.gameObject);       //Keep it around between loads
            Input.simulateMouseWithTouches = true;      //Needs to be set to emulate mouse with touch
        } else if(IM!=this) {       //Don't allow duplicates
            Destroy(gameObject);
        }	
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
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
            mSelected.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            InputText.text = string.Format("{0:f2} {1},", mSelected.gameObject.name, (Vector2)mSelected.transform.position);        //Debug text
        }
    }

    void    SelectGO(GameObject vGO,bool vSelect) {         //Select GameObject if it has a selection script
        Select tSelect = vGO.GetComponent<Select>();
        if (tSelect != null) {
            tSelect.Selected = vSelect;
        }
    }
}
