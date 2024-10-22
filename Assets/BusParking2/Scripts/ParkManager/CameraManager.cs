//--------------------------------------------------------------
//
//             Bus Parking kit 2 Update 2016-2021
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for manage car cameras

using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	// Array Of the total cameras
	[HideInInspector]public Camera[] Cams;

	[Header("Enter the camera name")]
	[Space(7)]
	public string[] camerasName;

	// Controlled with trailer camera trigger
	[HideInInspector]public bool canChangeCamera;

	IEnumerator Start () {

		Cams = new Camera[camerasName.Length];

		canChangeCamera = true;

		yield return new WaitForEndOfFrame ();

		// Find  MainCamera (with SmoothFollow script) as first camera 
		for (int a = 0; a < Cams.Length; a++) 
		{
			Cams [a] = GameObject.Find(camerasName [a]).GetComponent<Camera>(); 
		}
		
	    // Diactivate all cameras and activate first camera
		for (int a = 0; a<Cams.Length; a++) 
		{
			Cams[a].enabled =(false);
			Cams[CameraID].enabled= (true);
		}
	}
	

	// current camera id
	int CameraID;


	//public function for changing camera button that called    from UI OnClick() Button
	public void NextCam()
	{
		if (canChangeCamera) {
			if (CameraID < Cams.Length - 1)
				CameraID++;
			else
				CameraID = 0;

			for (int a = 0; a < Cams.Length; a++)
				Cams [a].enabled = (false);

			Cams [CameraID].enabled = (true);
			
			if (PlayerPrefs.GetInt("ColorEffects") != 3)
				Cams[CameraID].GetComponent<MobileColorGrading>().enabled = false;
			else
				Cams[CameraID].GetComponent<MobileColorGrading>().enabled = true;
		}

	}


	public void ActivateCam(int index)
	{

		for (int a = 0; a<Cams.Length; a++) 
			Cams[a].enabled= false;

		Cams[index].enabled= true;

	}
}
