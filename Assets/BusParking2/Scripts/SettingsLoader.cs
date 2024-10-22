//--------------------------------------------------------------
//
//                    Car Parking Kit
//          Writed by AliyerEdon in summer 2016
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for load game settings
using UnityEngine;
using System.Collections;

public class SettingsLoader : MonoBehaviour {


	public AudioSource AmbiantSound;
	public Camera mainCamera;

	void Start () {
		if (PlayerPrefs.GetInt ("AmbientSound") == 3)
			AmbiantSound.Play ();
		else
			AmbiantSound.Stop ();

		if (!mainCamera)
			mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		
		if (PlayerPrefs.GetInt ("ColorEffects") != 3)
			mainCamera.GetComponent<MobileColorGrading> ().enabled = false;
		else
			mainCamera.GetComponent<MobileColorGrading> ().enabled = true;	
		
		if (PlayerPrefs.GetInt ("SunShaft") != 3)
			mainCamera.GetComponent<LightingBox.ImageEffects.SunShafts> ().enabled = false;
		else
			mainCamera.GetComponent<LightingBox.ImageEffects.SunShafts> ().enabled = true;	
	}
}
