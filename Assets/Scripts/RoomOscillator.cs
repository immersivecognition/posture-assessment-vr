using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOscillator : MonoBehaviour {

	bool isOscillating = false;
	float amp;
	float period;

	float refTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isOscillating)
		{
			float t = RelTime();
			float x = amp * Mathf.Sin(t * 2*Mathf.PI / period);
			Vector3 angles = transform.eulerAngles;
			angles.x = x;
			transform.eulerAngles = angles;
		}
	}

	float RelTime()
	{
		return Time.time - refTime;
	}

	public void StartOscillation(float period, float amp)
	{
		refTime = Time.time;
		this.period = period;
		this.amp = amp;
		isOscillating = true;
	}

	public void StopOscillation()
	{
		isOscillating = false;
		Vector3 angles = transform.eulerAngles;
        angles.x = 0f;
        transform.eulerAngles = angles;
	}

}
