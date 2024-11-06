//--------------------------------------------------------------
//
//                    Car Parking Kit
//          Writed by AliyerEdon in summer 2016-2021
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for success menu buttons

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Success : MonoBehaviour
{
	[Header("Success Menu Manager")]

	// Loading text for "Loading..."
	public Text LoadingTXT;

	// Parking Manager handler
	[HideInInspector]public ParkingManager manager;

	public string garageName = "Garage Bus" ;

	public VehicleType vehicleType;


	// Activate parking place helper
	public void  ActiveHelper ()
	{
		manager.Helper.SetActive (!manager.Helper.activeSelf);
	}


	public IEnumerator Start ()
	{

		// Delay and find manager
		yield return new WaitForSeconds (.3f);
		manager = GameObject.FindGameObjectWithTag ("Manager").GetComponent<ParkingManager> ();
	}

	// SuccessMenu continue button
	public void Continue ()
	{
		LoadingTXT.text = "Loading...";

		if(vehicleType == VehicleType.Bus)
			PlayerPrefs.SetInt ("BusLevelID", PlayerPrefs.GetInt ("BusLevelID") + 1);
		if(vehicleType == VehicleType.Truck)
			PlayerPrefs.SetInt ("TruckLevelID", PlayerPrefs.GetInt ("TruckLevelID") + 1);
		if(vehicleType == VehicleType.Car)
			PlayerPrefs.SetInt ("CarLevelID", PlayerPrefs.GetInt ("CarLevelID") + 1);
		
		SceneManager.LoadScene  (SceneManager.GetActiveScene().name);
	}


	// SuccessMenu retry button
	public void Retry ()
	{
		LoadingTXT.text = "Loading...";
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name   );
	}


	//SuccessMenu exit button    
	public void Exit ()
	{
		LoadingTXT.text = "Loading...";
		SceneManager.LoadScene (garageName);
	}
}
