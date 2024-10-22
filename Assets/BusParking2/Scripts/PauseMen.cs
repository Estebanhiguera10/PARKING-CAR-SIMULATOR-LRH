//--------------------------------------------------------------
//
//                    Car Parking Kit
//          Writed by AliyerEdon in summer 2016
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for level Pause menu system   

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMen : MonoBehaviour
{
	[Header("Pause Menu Manager")]


	public GameObject PauseMenu;
	public Text LoadingText, AllScore;

	public string garageName  = "Garage Bus";

	public void Pause ()
	{
		PauseMenu.SetActive (true);
		AllScore.text = "Total Score is :   "+PlayerPrefs.GetInt ("Coins").ToString ();
		Time.timeScale = 0f;
	}

	public void Resume ()
	{
		PauseMenu.SetActive (false);
		Time.timeScale = 1f;
	}



	public void Retry ()
	{
		LoadingText.text = "Please Wait...";
		PauseMenu.SetActive (false);
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);


	}

	public void Exit ()
	{
		Time.timeScale = 1f;
		LoadingText.text = "Please Wait...";
		SceneManager.LoadScene(garageName);
	}


	public void SetFalse(GameObject target)
	{


		target.SetActive (false);
	}

	public void SetTrue(GameObject target)
	{

		target.SetActive (true);
	}
}
