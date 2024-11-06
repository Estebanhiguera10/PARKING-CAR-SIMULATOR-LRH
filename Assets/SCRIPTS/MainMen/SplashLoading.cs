using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashLoading : MonoBehaviour {

	public string levelName;

	void Start () {
		SceneManager.LoadSceneAsync(levelName);
	}

}
