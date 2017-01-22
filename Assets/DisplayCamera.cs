using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayCamera : MonoBehaviour {

    private WebCamTexture mCamera = null;

    public	TextMesh 	TM;
	public	Toggle		CameraToggle;

	Renderer	mR;

	Texture		mDefaultTex;

    // Use this for initialization
    void Start () {
        mR = GetComponent<Renderer>();			//Renderer reference
		mDefaultTex = mR.material.mainTexture;			//Keep Default Texture
		SetCamera();
    }

	public	void	SetCamera() {
		ShowVideo(CameraToggle.isOn);		//Turn Camera on
	}

	void	ShowVideo(bool vShow) {
		if (vShow) {
			foreach (WebCamDevice tWC in WebCamTexture.devices) {
				if (!tWC.isFrontFacing) {
					mCamera = new WebCamTexture (tWC.name);	//Get WebCam Texture
					break;
				}
			}
			if (mCamera == null) {  //If no front camera use default
				mCamera = new WebCamTexture ();
			}
			if (mCamera != null) {
				mR.material.mainTexture = mCamera;				//Use Camera feed as texture
				mCamera.wrapMode = TextureWrapMode.Clamp;		//Show single texture no wrap
				mCamera.Play ();		//Start Feed
				if (TM != null)
					TM.text = "Live";
			} else {
				mR.material.color = Color.clear;
				if (TM != null)
					TM.text = "No Camera";
			}
		} else {
			if (mCamera != null && mCamera.isPlaying) {		//Stop play
				mCamera.Stop ();
			}
			mR.material.mainTexture = mDefaultTex;		//Put back default texture
			mCamera = null;
			if (TM != null)
				TM.text = "Stop";
		}
	}
}
