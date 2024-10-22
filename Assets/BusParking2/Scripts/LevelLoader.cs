//--------------------------------------------------------------
//
//                    Car Parking Kit
//          Writed by AliyerEdon in summer 2016
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for load and activate level that selected in main menu     

using UnityEngine;
using System.Collections;
public class LevelLoader : MonoBehaviour
{
	
	// Use this for initialization
	public GameObject[] Levels;

	//List of the car prefabs
	public GameObject[] Cars;

	void Start ()
	{
		Levels [PlayerPrefs.GetInt ("BusLevelID")].SetActive (true);
	}
}
