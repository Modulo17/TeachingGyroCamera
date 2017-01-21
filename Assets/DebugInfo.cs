using UnityEngine;
using System.Collections;
using UnityEngine.UI;           //Need to add this to ensure we get access to UI elements


public class DebugInfo : MonoBehaviour {

    public Text DebugText;          //Link this in Inspector

	void Start () {
	}
	
	void Update () {
        DebugText.text = string.Format("{0} ({1},{2})", Screen.orientation,Screen.width, Screen.height);
    }
}
