//--------------------------------------------------------------
//
//                   Bus Parking Kit 2
//          Writed by AliyerEdon in summer 2016-2021
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for game settings menu

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Settings : MonoBehaviour
{

	// Use this for initialization
	public Toggle AmbientSound, SunShaft,ColorEffects;

	// States info text
	public Text qualityState;

	void Start ()
	{

		// Read starting setting values
		if (PlayerPrefs.GetInt ("AmbientSound") == 3)
			AmbientSound.isOn = true;
		else
			AmbientSound.isOn = false;
		
		if (PlayerPrefs.GetInt ("SunShaft") == 3)
			SunShaft.isOn = true;
		else
			SunShaft.isOn = false;


		if (PlayerPrefs.GetInt ("ColorEffects") == 3)
			ColorEffects.isOn = true;
		else
			ColorEffects.isOn = false;
		

		if (PlayerPrefs.GetInt ("Quality") == 0)
			qualityState.text = "Fastest";
		if (PlayerPrefs.GetInt ("Quality") == 3)
			qualityState.text = "Good";
		if (PlayerPrefs.GetInt ("Quality") == 5)
			qualityState.text = "Fantastic";
	}

	// Public function for ambient sound toggle
	public void Set_AmbientSound ()
	{
		StartCoroutine (AmbiantSound_Save ());
	}

	public void Set_SunShaft ()
	{
		StartCoroutine (SunShaft_Save ());
	}

	public void Set_ColorEffects ()
	{
		StartCoroutine (ColorEffects_Save ());
	}
	public void SetQualityLevel (int id)
	{
		PlayerPrefs.SetInt ("Quality", id);
		QualitySettings.SetQualityLevel (id, false);

		if (id == 0)
			qualityState.text = "Fastest";
		if (id == 3)
			qualityState.text = "Good";
		if (id == 5)
			qualityState.text = "Fantastic";
	}

	IEnumerator AmbiantSound_Save ()
	{
		yield return new WaitForSeconds (.3f);
		if (AmbientSound.isOn)
			PlayerPrefs.SetInt ("AmbientSound", 3);  //3 = true;
		else
			PlayerPrefs.SetInt ("AmbientSound", 0);//0 = false;
	}
	IEnumerator ColorEffects_Save ()
	{
		yield return new WaitForSeconds (.3f);
		if (ColorEffects.isOn)
			PlayerPrefs.SetInt ("ColorEffects", 3);  //3 = true;
		else
			PlayerPrefs.SetInt ("ColorEffects", 0);//0 = false;
	}


	IEnumerator SunShaft_Save ()
	{
		yield return new WaitForSeconds (.3f);
		if (SunShaft.isOn)
			PlayerPrefs.SetInt ("SunShaft", 3);  //3 = true;
		else
			PlayerPrefs.SetInt ("SunShaft", 0);//0 = false;
	}





}
