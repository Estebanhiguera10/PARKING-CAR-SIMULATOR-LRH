using UnityEngine;
using System.Collections;

public class GarageCamera : MonoBehaviour {


	public Transform target;

	public Vector3[] camPosition;

	public float cameraMoveSpeed = 1F;


	IEnumerator Start () {
	

		yield return new WaitForEndOfFrame ();

	}
	

	void Update () {
		
		if (!target)
			return;


		transform.LookAt (target.position);


		if (Input.GetKeyDown (KeyCode.N))
			NextTarget ();
		
	}

	int targetPosition;

	public void NextTarget()
	{
		if (targetPosition < camPosition.Length - 1)
			targetPosition += 1;
		else
			targetPosition = 0;



		StartCoroutine (MoveResource (transform, camPosition [targetPosition], cameraMoveSpeed));


	}
	public void DeActivateTarget()
	{
		if (targetPosition == 1) {
			targetPosition = 0;

			StartCoroutine (MoveResource (transform, camPosition [targetPosition], cameraMoveSpeed));

		}
	}
	public void GoTarget(int number)
	{

		StartCoroutine (MoveResource (transform, camPosition [targetPosition], cameraMoveSpeed));
	}

	IEnumerator MoveResource(Transform resourceTransform,Vector3 endPosition,float speed)
	{
		Vector3 startPosition = resourceTransform.position;
		float t = 0.0f;
		while (t < 1.0f)
		{
			t += Time.deltaTime * speed;
			resourceTransform.position = Vector3.Lerp(startPosition, endPosition, t);
			yield return null;
		}
	}

	public void SetTarget(Transform transform_t)
	{

		target = transform_t;
	}
}


