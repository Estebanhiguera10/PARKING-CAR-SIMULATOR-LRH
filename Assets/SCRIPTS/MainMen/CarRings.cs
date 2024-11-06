using UnityEngine;
using System.Collections;

public class CarRings : MonoBehaviour {

	public GameObject[] rings_0,rings_1,rings_2,rings_3;


	int carID;
	void Awake()
	{
		carID = PlayerPrefs.GetInt ("CarID");

		if (PlayerPrefs.GetInt (carID.ToString()+"RingID") == 0) {
			for (int a = 0; a <  rings_0.Length; a++) {
				 rings_0 [a].SetActive (true);
				 rings_1 [a].SetActive (false);
				 rings_2 [a].SetActive (false);
				 rings_3 [a].SetActive (false);
			}
		}
		if (PlayerPrefs.GetInt (carID.ToString()+"RingID") == 1) {
			for (int a = 0; a <  rings_1.Length; a++) {
				 rings_1 [a].SetActive (true);
				 rings_0 [a].SetActive (false);
				 rings_2 [a].SetActive (false);
				 rings_3 [a].SetActive (false);
			}
		}
		if (PlayerPrefs.GetInt (carID.ToString()+"RingID") == 2) {
			for (int a = 0; a <  rings_2.Length; a++) {
				 rings_2 [a].SetActive (true);
				 rings_1 [a].SetActive (false);
				 rings_0 [a].SetActive (false);
				 rings_3 [a].SetActive (false);
			}
		}
		if (PlayerPrefs.GetInt (carID.ToString()+"RingID") == 3) {
			for (int a = 0; a <  rings_3.Length; a++) {
				 rings_3 [a].SetActive (true);
				 rings_1 [a].SetActive (false);
				 rings_2 [a].SetActive (false);
				 rings_0 [a].SetActive (false);
			}
		}
	}
}
