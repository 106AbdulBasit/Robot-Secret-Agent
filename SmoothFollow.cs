// Smooth Follow from Standard Assets
// Converted to C# because I fucking hate UnityScript and it's inexistant C# interoperability
// If you have C# code and you want to edit SmoothFollow's vars ingame, use this instead.
using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{
    
	// The target we are following
	public Transform target;
	// The distance in the x-z plane to the target
	public float distance = 10.0f;
	// the height we want the camera to be above the target
	public float height = 5.0f;
	// How much we
	public float heightDamping = 2.0f;
	public float rotationDamping = 3.0f;
	public float yRotation;
	int timesClick = 1;
	// Place the script in the Camera-Control group in the component menu
	[AddComponentMenu ("Camera-Control/Smooth Follow")]


	void Start ()
	{
//		Debug.Log ("from start");
		Invoke ("SetTarget", 0.5f);
//		SetTarget ();	
	}
	//	public void SetTarget(){
	//
	//		target = selectedPlayerBus[PlayerPrefs.GetInt("CarNo")];
	//
	//
	//	}

	public void SetTarget (Transform tar)
	{
		target = tar;
	}


	void LateUpdate ()
	{
		// Early out if we don't have a target
		if (!target)
			return;
		if (true) {
			// Calculate the current rotation angles
			float wantedRotationAngle = target.eulerAngles.y;
			float wantedHeight = target.position.y + height;

			float currentRotationAngle = transform.eulerAngles.y;
			float currentHeight = transform.position.y;

			// Damp the rotation around the y-axis
			currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle+(yRotation), rotationDamping * Time.deltaTime);
	
			// Damp the height
			currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);

			// Convert the angle into a rotation
			var currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
	
			// Set the position of the camera on the x-z plane to:
			// distance meters behind the target
			transform.position = target.position;
			transform.position -= currentRotation * Vector3.forward * distance;

			// Set the height of the camera
			transform.position = new Vector3 (transform.position.x, currentHeight, transform.position.z);
	
			// Always look at the target
			transform.LookAt (target);

		}
	}

	public void OnCamera()
	{

		if (timesClick == 1) 
		{
			distance = 5f;
			height = 1f;
			yRotation =  129.67f;
			timesClick = 2;
		}

		else if (timesClick == 2) 
		{
			distance = 5f;
			height = 1f;
			yRotation =  180.67f;

			timesClick = 3;
		}

		else if (timesClick == 3) 
		{
			distance = 5f;
			height = 1f;
			yRotation =  222.67f;

			timesClick = 0;
		}

		else if(timesClick == 0)
		{
			distance = 4f;
			height = 1f;
			yRotation =  0f;

			timesClick = 1;
		}
	}
}