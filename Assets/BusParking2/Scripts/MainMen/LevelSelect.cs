//--------------------------------------------------------------
//
//                    Car Parking Kit
//          Writed by AliyerEdon in summer 2016-2021
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for level selection and lock system in game menu

using UnityEngine;
using System.Collections;   
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{

	// Array of locks
	public GameObject[] Locks;
	    
	// Temp
	public int temp;

	// Next menu for activat it
	public GameObject LevelSelectMenu, CarSelectMenu;

	// Night mode togle
	public Toggle nightMode;

	public Text[] bestTime;



	public VehicleType vehicleType;




	void Start ()
	{
		if (vehicleType == VehicleType.Car) {
			//Level  num   is  :   3
			temp = PlayerPrefs.GetInt ("CarLevelNum");
			for (int a = 0; a <= temp; a++) {
				if (temp > a)
					Locks [a].SetActive (false);
			}
		}
		if (vehicleType == VehicleType.Bus) {
			//Level  num   is  :   3
			temp = PlayerPrefs.GetInt ("BusLevelNum");
			for (int a = 0; a <= temp; a++) {
				if (temp > a)
					Locks [a].SetActive (false);
			}
		}
		if (vehicleType == VehicleType.Truck) {
			//Level  num   is  :   3
			temp = PlayerPrefs.GetInt ("TruckLevelNum");
			for (int a = 0; a <= temp; a++) {
				if (temp > a)
					Locks [a].SetActive (false);
			}
		}
		if (PlayerPrefs.GetInt ("NightMode") == 3)  // 3 => true, 0 => false
			nightMode.isOn = true;
		else
			nightMode.isOn = false;


		if (vehicleType == VehicleType.Car) {
			for (int aa = 0; aa < bestTime.Length; aa++) {

				float min = PlayerPrefs.GetFloat ("CarMinutes" + aa.ToString ());
				float secn = PlayerPrefs.GetFloat ("CarSeconds" + aa.ToString ());

				string minS, secS;

				minS = min.ToString ();
				secS = Mathf.Floor (secn).ToString ();

				if (min < 10)
					minS = "0" + min.ToString ();

				if (secn < 10)
					secS = "0" + Mathf.Floor (secn).ToString ();


				bestTime [aa].text = (minS + ":" + secS)
				.ToString ();
			}
		}
		if (vehicleType == VehicleType.Bus) {
			for (int aa = 0; aa < bestTime.Length; aa++) {

				float min = PlayerPrefs.GetFloat ("BusMinutes" + aa.ToString ());
				float secn = PlayerPrefs.GetFloat ("BusSeconds" + aa.ToString ());

				string minS, secS;

				minS = min.ToString ();
				secS = Mathf.Floor (secn).ToString ();

				if (min < 10)
					minS = "0" + min.ToString ();

				if (secn < 10)
					secS = "0" + Mathf.Floor (secn).ToString ();


				bestTime [aa].text = (minS + ":" + secS)
					.ToString ();
			}
		}

		if (vehicleType == VehicleType.Truck) {
			for (int aa = 0; aa < bestTime.Length; aa++) {

				float min = PlayerPrefs.GetFloat ("TruckMinutes" + aa.ToString ());
				float secn = PlayerPrefs.GetFloat ("TruckSeconds" + aa.ToString ());

				string minS, secS;

				minS = min.ToString ();
				secS = Mathf.Floor (secn).ToString ();

				if (min < 10)
					minS = "0" + min.ToString ();

				if (secn < 10)
					secS = "0" + Mathf.Floor (secn).ToString ();


				bestTime [aa].text = (minS + ":" + secS)
					.ToString ();
			}
		}
	}

	public void LoadLevel (int id)
	{
		if (vehicleType == VehicleType.Car) {
			if (id < temp) {
				PlayerPrefs.SetInt ("CarLevelID", id);
				CarSelectMenu.SetActive (true);
				LevelSelectMenu.SetActive (false);
			}
		}
		if (vehicleType == VehicleType.Bus) {
			if (id < temp) {
				PlayerPrefs.SetInt ("BusLevelID", id);
				CarSelectMenu.SetActive (true);
				LevelSelectMenu.SetActive (false);
			}
		}
		if (vehicleType == VehicleType.Truck) {
			if (id < temp) {
				PlayerPrefs.SetInt ("TruckLevelID", id);
				CarSelectMenu.SetActive (true);
				LevelSelectMenu.SetActive (false);
			}
		}

	}

	public void SetNightMode()
	{
		StartCoroutine (SaveNightMode ());
	}
	IEnumerator SaveNightMode()
	{

		yield return new WaitForSeconds (0.3f);
		if (nightMode.isOn)
			PlayerPrefs.SetInt ("NightMode", 3);  // 3 => true
		else
			PlayerPrefs.SetInt ("NightMode", 0);  // 0 => false
	}
}
