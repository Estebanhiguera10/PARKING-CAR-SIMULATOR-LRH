//--------------------------------------------------------------
//
//                    Car Parking Kit
//          Edited by AliyerEdon in summer 2016-2021
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for manage mobile input system

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public enum InputType
{
	Touch,Keyboard
}
public class CarInput : MonoBehaviour
{
	
	// Main car controller handler
	[HideInInspector]public CarController carController;
	[Header("Car Input Manager")]

	public InputType inputType = InputType.Keyboard;
	public bool autoSwitchControls = true;

	// SteeringWheel handler
	public SteeringWheel SW;
	public GameObject mobileControls;

	// Internal values for Throttle,Steer,Brake and ...
	[HideInInspector]public float SteerInput, ThrottleInput, BrakeInput, HandBrakeInput;

	// Is game started?
	bool started;

	[Space(1)]
	// Reverse sprites
	public Sprite ReverseSprite_D,ReverseSprite_R;

	[Space(1)]
	// Reverse button image
	public Image ReverseTarget;

	// Helper arrow handler for acitivate ans deActivate;
	[HideInInspector]public GameObject helperArrow;

	// Reversing alarm
	[HideInInspector]public AudioSource reverseAlarm;


	bool isReverseTemp;


	public GameObject arrowControlls,steeringWheelControll;
	int controllType = 0;

	// Accelerometer controlling
	Vector3 zeroAc;
	Vector3 curAc;
	public float accelSensibility  = 10f;
	public float accelSmooth = 0.5f;
	float GetAxisH = 0f;

	// Find player after car spawned
	IEnumerator Start()
	{
		if (autoSwitchControls)
		{
#if UNITY_EDITOR || UNITY_WEBGL || UNITY_STANDALONE || UNITY_WSA || UNITY_64
			inputType = InputType.Keyboard;
#else
								inputType = InputType.Touch;			
#endif
		}

		// Disable mobile control on keyboard mode
		if (inputType == InputType.Keyboard)
			mobileControls.SetActive(false);

		yield return new WaitForSeconds (.03f);
		helperArrow = GameObject.FindGameObjectWithTag ("Helper");
		helperArrow.SetActive (false);
		controllType = 0;
		if (PlayerPrefs.GetInt ("Controll") == 0) {
			arrowControlls.SetActive (true);
			steeringWheelControll.SetActive (false);
			controllType = 0;
		}
		if (PlayerPrefs.GetInt ("Controll") == 1) {
			arrowControlls.SetActive (false);
			steeringWheelControll.SetActive (true);
			controllType = 1;
		}
		if (PlayerPrefs.GetInt ("Controll") == 2) {
			arrowControlls.SetActive (false);
			steeringWheelControll.SetActive (false);
			controllType = 2;
		}
		// Delay for car spawn
		yield return new WaitForSeconds (.3f);



		// Find car by tag
		 carController = GameObject.FindGameObjectWithTag ("Player").GetComponent<CarController> ();

		// Game is now started
		started = true;

		reverseAlarm = carController.reverseAlram;
	}

	bool ReverseGear;

	void Update ()
	{
		if (started) {

			if (inputType == InputType.Touch)
			{
				// Read accelerometer input    
				curAc = Vector3.Lerp(curAc, Input.acceleration - zeroAc, Time.deltaTime / accelSmooth);
				GetAxisH = Mathf.Clamp(curAc.x * accelSensibility, -1, 1);

				if (controllType == 1)
					SteerInput = SW.GetClampedValue();

				if (controllType == 2)
					SteerInput = GetAxisH;
			}

			if(inputType == InputType.Keyboard)
				SteerInput = Input.GetAxis("Horizontal");
			


			// Send input values to CarController script
			carController.Move (SteerInput, ThrottleInput, BrakeInput, HandBrakeInput,isReverseTemp);

			if (Input.GetKey (KeyCode.E)) {
				Debug.Log ("SteerInput: " + SteerInput.ToString () + " ThrottleInput : " + ThrottleInput.ToString () +
				"BrakeInput: " + BrakeInput.ToString () + " HandBrakeInput : " + HandBrakeInput.ToString () +
				" isReverseTemp : " + isReverseTemp.ToString ());
			}
			// Keyboard controlling

			if (inputType == InputType.Keyboard) { 
				if (Input.GetKey (KeyCode.W))
				Throttle ();
			else
				ThrottleRalease ();

			if (Input.GetKey (KeyCode.S))
				Brake (true);
			else
				Brake (false);

			if (Input.GetKeyDown (KeyCode.C))
				GetComponent<CameraManager> ().NextCam ();

			if (Input.GetKeyDown (KeyCode.H))
				ToggleHelper ();

			if (Input.GetKeyDown (KeyCode.Escape))
				GetComponent<PauseMen> ().Pause ();

				if (Input.GetKeyDown(KeyCode.R))
					ToggleReverse();
			}
		}
	}

	// This is for Throttle UI Button when pressed
	public void Throttle ()
	{
		if (!ReverseGear) 
		{

			ThrottleInput = 1f;
			BrakeInput = 0;
		} 
		else 
		{
			BrakeInput = -1f;


			isReverseTemp = true;

			if (reverseAlarm) {
				if (!reverseAlarm.isPlaying)
					reverseAlarm.Play ();
			}


		}
	}
	// This is for Throttle UI Button when released
	public void ThrottleRalease ()
	{


		ThrottleInput = 0;

		BrakeInput = 0;

		if(reverseAlarm)
		{
			if (reverseAlarm.isPlaying)
				reverseAlarm.Stop ();
		}

		isReverseTemp = false;

	}
	// This is for Throttle UI Button when pressed and released
	public void Brake (bool press)
	{
		if (press) {
			
			HandBrakeInput = 1f;

			// Light intensity controll
			carController.backLights [0].intensity = HandBrakeInput;
			carController.backLights [1].intensity = HandBrakeInput;
		}

			if (!press) 
			{
				
		HandBrakeInput = 0;

				carController.backLights [0].intensity = 0;
				carController.backLights [1].intensity = 0;

			}
		
	}
	// This is for HandBrake UI Button when pressed
	public void HandBrake (bool press)
	{
		if (press)
			HandBrakeInput = 1f;
		else
			HandBrakeInput = 0;
	}

	public void ToggleReverse()
	{
		ReverseGear = !ReverseGear;

		if (!ReverseGear)
			ReverseTarget.sprite = ReverseSprite_D;
		else
			ReverseTarget.sprite = ReverseSprite_R;
	}

	public void ToggleHelper()
	{
		helperArrow.SetActive (!helperArrow.activeSelf);
	}
	float velocityRef;
	public void Steer(bool left)
	{

		if (left)
			SteerInput = -1f;
		else
			SteerInput = 1f;    
	}

	public void SteerRelease()
	{
			SteerInput  =  0;
	}

	void ResetAxes(){
		zeroAc = Input.acceleration;
		curAc = Vector3.zero;
	}
   
}
