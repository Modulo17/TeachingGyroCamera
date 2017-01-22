using UnityEngine;
using System.Collections;

public class DisplayCamera : MonoBehaviour {


    private WebCamTexture mCamera = null;

    public	TextMesh TM;

    // Use this for initialization
    void Start () {
        Renderer tR = GetComponent<Renderer>();
        foreach (WebCamDevice tWC in WebCamTexture.devices) {
            if(!tWC.isFrontFacing) {
                mCamera = new WebCamTexture(tWC.name);	//Get WebCam Texture
                break;
            }
        }
        if (mCamera == null) {  //If no front camera use default
            mCamera = new WebCamTexture();
        }
        if(mCamera!=null) {
            foreach(Material tM in tR.materials) {
                tM.mainTexture = mCamera;					//Add Texture to all Materials
				mCamera.wrapMode = TextureWrapMode.Clamp;
            }
            mCamera.Play();		//Start Feed
			if(TM!=null) 	TM.text = "Live";
        } else {
            tR.material.color=Color.clear;
			if(TM!=null) 	TM.text = "No Camera";
        }
    }
}
