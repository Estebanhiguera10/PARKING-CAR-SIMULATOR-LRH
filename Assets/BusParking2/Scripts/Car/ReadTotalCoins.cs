using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadTotalCoins : MonoBehaviour {

	// Use this for initialization
	public Text coinsTXT;

	void Start () {
		coinsTXT.text = "Total Scores : "  + PlayerPrefs.GetInt ("Coins").ToString ();
	}
}
