using UnityEngine;
using System.Collections;

public class DragCamera : MonoBehaviour {


	CameraMove cm;

	IEnumerator Start () {
		
		yield return new WaitForEndOfFrame ();

		cm = GameObject.FindGameObjectWithTag ("Camera4").GetComponent<CameraMove> ();
	}
	
	public void EnableDrag(bool state)
	{
		if (state)
			cm.canDrag = true;
		else
			cm.canDrag = false ;

	}
}
