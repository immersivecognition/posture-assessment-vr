using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMeasurementTool : MonoBehaviour {

	public Transform leftHand;
	public Transform rightHand;
	public Transform head;

	/// <summary>
	/// A transform that is at floor level and which the local upwards (+y) is pointed against the gravity vector 
	/// </summary>
	public Transform floorUpMarker; 

	public float CalculateHeight()
	{
		return Vector3.Dot((head.position - floorUpMarker.position), floorUpMarker.TransformDirection(Vector3.up));
	}


    public float CalculateArmSpan()
    {
        return (leftHand.position - rightHand.position).magnitude;
    }

}
