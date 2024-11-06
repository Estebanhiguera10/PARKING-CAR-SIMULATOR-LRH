using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Helper : MonoBehaviour
{

	// Target for helper arrow lookAt
	GameObject Target;

	// Distance to target need to hide helper   arrow
	public float DistanceToHide;

	// Is game started and parking place activated?
	bool Started;

	IEnumerator Start ()
	{



		if ( SceneManager.GetActiveScene().name == "Garage")
			Destroy (gameObject);

	
		yield return new WaitForSeconds (.02f);
		Started = true;
		Target = GameObject.FindGameObjectWithTag ("ParkPlace");
	}

	// Update is called once per frame
	void Update ()
	{
		if (Started) {
			Vector3 eulerAngles = transform.rotation.eulerAngles;
			eulerAngles.x = 0;
			eulerAngles.z = 0;
		
			transform.rotation = Quaternion.Euler (eulerAngles);
		
		
			if (Target) {
				if (Vector3.Distance (transform.position, Target.transform.position) <= DistanceToHide)
					GetComponentInChildren<MeshRenderer> ().enabled = false;
				else {



					transform.LookAt (Target.transform.position
					);


				}
			}

		}
	}
}
