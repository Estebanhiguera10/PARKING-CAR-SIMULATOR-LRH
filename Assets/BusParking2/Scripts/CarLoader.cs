//--------------------------------------------------------------
//
//                    Car Parking Kit
//          Writed by AliyerEdon in summer 2016
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for load and instantiate car that selected in garage

using UnityEngine;
using System.Collections;


public class CarLoader : MonoBehaviour
{


	void Awake ()
	{
		// Instantiate car by loaded  Car ID from  selected in car garage   
		Instantiate (GetComponentInParent<LevelLoader>().Cars [PlayerPrefs.GetInt ("BusID")], transform.position, transform.rotation);
	}
}
