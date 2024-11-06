//--------------------------------------------------------------
//
//                    Car Parking Kit
//          Writed by AliyerEdon in summer 2016-2021
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This is collision detection script that increase CollisionCount in TriggerManager.cs 
//If collision count is more than 3,Finish Menu be activated from TriggerManager.cs

using UnityEngine;
using System.Collections;

public class CollisionItem : MonoBehaviour
{
	//Accessing to TriggerManager.cs
	[HideInInspector]public ParkingManager triggerManager;

	//This is for internal usage
	bool CanCollid;

	void Start ()
	{
		//Find TriggerManager by tag
		triggerManager = GameObject.FindGameObjectWithTag ("Manager").GetComponent<ParkingManager> ();

	}
	//When car is colide with parking items
	void OnCollisionEnter (Collision col)
	{
		if (!CanCollid) {
			if (col.gameObject.tag == "Player") {
				
				//Increase TriggerManager Collision Counts
				triggerManager.CollisionCount++;

				//Play collision Alarm sound
				triggerManager.AlarmSound.Play();

				//Internal usage--------------------
				CanCollid = true;
				StartCoroutine (CanCollids ());
				//---------------------

				//Update collision count text
				triggerManager.CollistionCountText.text = triggerManager.CollisionCount.ToString ();

				//If collision counts is more than 3,Stop game and show Failed menu Object
				if (triggerManager.CollisionCount > 3) {
					triggerManager.FailedMenu.SetActive (true);
					triggerManager.Controller.SetActive (false);
					GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody> ().isKinematic = true;
					//Destroy TriggerManager
					Destroy (triggerManager);
				}
			}
		}
	}

	//Internal Usage....
	IEnumerator CanCollids ()
	{


		yield return new WaitForSeconds (3f);
		CanCollid = false;
	}
}
