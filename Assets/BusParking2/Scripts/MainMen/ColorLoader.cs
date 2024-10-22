//--------------------------------------------------------------
//
//                    Car Parking Kit
//          Writed by AliyerEdon in summer 2016-2021
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for load car color that selected in game menu(garage)

using UnityEngine;
using System.Collections;

public class ColorLoader : MonoBehaviour {

	// List of the car colors
	public Color[] Colors;

	// Car material for changing color
	public Material mat;

	// Car ID for read car color
	public string CarID   ;

	public VehicleType vehicleType;
	void Start () {
		if (vehicleType == VehicleType.Car) {
			// Load last selected color by ID
			if (PlayerPrefs.GetInt ("CarColor" + CarID) == 0)
				mat.color = Colors [0];
			if (PlayerPrefs.GetInt ("CarColor" + CarID) == 1)
				mat.color = Colors [1];
			if (PlayerPrefs.GetInt ("CarColor" + CarID) == 2)
				mat.color = Colors [2];
			if (PlayerPrefs.GetInt ("CarColor" + CarID) == 3)
				mat.color = Colors [3];
			if (PlayerPrefs.GetInt ("CarColor" + CarID) == 4)
				mat.color = Colors [4];
			if (PlayerPrefs.GetInt ("CarColor" + CarID) == 5)
				mat.color = Colors [5];
			if (PlayerPrefs.GetInt ("CarColor" + CarID) == 6)
				mat.color = Colors [6];
			if (PlayerPrefs.GetInt ("CarColor" + CarID) == 7)
				mat.color = Colors [7];

		}
		if (vehicleType == VehicleType.Bus) {
			// Load last selected color by ID
			if (PlayerPrefs.GetInt ("BusColor" + CarID) == 0)
				mat.color = Colors [0];
			if (PlayerPrefs.GetInt ("BusColor" + CarID) == 1)
				mat.color = Colors [1];
			if (PlayerPrefs.GetInt ("BusColor" + CarID) == 2)
				mat.color = Colors [2];
			if (PlayerPrefs.GetInt ("BusColor" + CarID) == 3)
				mat.color = Colors [3];
			if (PlayerPrefs.GetInt ("BusColor" + CarID) == 4)
				mat.color = Colors [4];
			if (PlayerPrefs.GetInt ("BusColor" + CarID) == 5)
				mat.color = Colors [5];
			if (PlayerPrefs.GetInt ("BusColor" + CarID) == 6)
				mat.color = Colors [6];
			if (PlayerPrefs.GetInt ("BusColor" + CarID) == 7)
				mat.color = Colors [7];

		}
		if (vehicleType == VehicleType.Truck) {
			// Load last selected color by ID
			if (PlayerPrefs.GetInt ("TruckColor" + CarID) == 0)
				mat.color = Colors [0];
			if (PlayerPrefs.GetInt ("TruckColor" + CarID) == 1)
				mat.color = Colors [1];
			if (PlayerPrefs.GetInt ("TruckColor" + CarID) == 2)
				mat.color = Colors [2];
			if (PlayerPrefs.GetInt ("TruckColor" + CarID) == 3)
				mat.color = Colors [3];
			if (PlayerPrefs.GetInt ("TruckColor" + CarID) == 4)
				mat.color = Colors [4];
			if (PlayerPrefs.GetInt ("TruckColor" + CarID) == 5)
				mat.color = Colors [5];
			if (PlayerPrefs.GetInt ("TruckColor" + CarID) == 6)
				mat.color = Colors [6];
			if (PlayerPrefs.GetInt ("TruckColor" + CarID) == 7)
				mat.color = Colors [7];

		}


	}


}
