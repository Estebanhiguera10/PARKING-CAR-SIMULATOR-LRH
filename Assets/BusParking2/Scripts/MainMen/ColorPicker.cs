//--------------------------------------------------------------
//
//                    Car Parking Kit
//          Writed by AliyerEdon in summer 2016-2021
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for color picking system in game menu(garage)

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorPicker : MonoBehaviour {

	// List of the colors
	public Color[] Colors;

	public VehicleType vehicleType;

	// Public function for changing color buttons
	public void SetColor (int id)
	{
		if (vehicleType == VehicleType.Car) {
			PlayerPrefs.SetInt ("CarColor" + PlayerPrefs.GetInt ("CarID").ToString (), id);
		}
		if (vehicleType == VehicleType.Bus) {
			PlayerPrefs.SetInt ("BusColor" + PlayerPrefs.GetInt ("BusID").ToString (), id);
		}

		if (vehicleType == VehicleType.Truck) {
			PlayerPrefs.SetInt ("TruckColor" + PlayerPrefs.GetInt ("TruckID").ToString (), id);
		}
 			GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<ColorLoader>().mat.color = Colors [id];

	}
}
