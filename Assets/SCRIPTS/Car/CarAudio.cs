using System;
using UnityEngine;
using Random = UnityEngine.Random;


[RequireComponent (typeof(CarController))]
public class CarAudio : MonoBehaviour
{
	public AudioClip EngineSound;

	public AudioSource reverseAlarm;

	public float pitchMultiplier = 1f;

	public float PitchMin = 1f;

	public float PitchMax = 6f;

	[HideInInspector]public AudioSource audioSource;


	private CarController m_CarController;   

	public float crashVelocity = 10f;

	private void Start ()
	{
		m_CarController = GetComponent<CarController> ();

		gameObject.AddComponent<AudioSource> ();

		audioSource = GetComponent<AudioSource>();

		audioSource.clip = EngineSound;
		   
		audioSource.loop = true;

		audioSource.Play ();

		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name.Contains ("Garage"))
			isGarage = true;
		else
			isGarage = false;
		
	}

	private void Update ()
	{
			// The pitch is interpolated between the min and max values, according to the car's revs.
			float pitch = ULerp (PitchMin, PitchMax, m_CarController.Revs);

			// clamp to minimum pitch (note, not clamped to max for high revs while burning out)
			pitch = Mathf.Min (PitchMax, pitch);

			audioSource.pitch = pitch * pitchMultiplier;

			//audioSource.volume = 1f;
	}

	private static float ULerp (float from, float to, float value)
	{
		return (1.0f - value) * from + value * to;   
	}

	public AudioSource crashSound;

	bool isGarage;

	void OnCollisionEnter(Collision collision)
	{

		if (collision.relativeVelocity.magnitude > crashVelocity) {

			if (!crashSound.isPlaying) {
				if(!isGarage)
					crashSound.Play ();

			}

		}
	}
}