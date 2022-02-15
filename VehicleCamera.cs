using UnityEngine;
using System.Collections;

public class VehicleCamera : MonoBehaviour
{



    public Transform target;
    public float smooth = 0.3f;
    public float distance = 5.0f;
    public float height = 1.0f;
    public float Angle = 20;
	public float yRotation;

    public Transform[] cameraSwitchView;
    public LayerMask lineOfSightMask = 0;

    private float yVelocity = 0.0f;
    private float xVelocity = 0.0f;
    public static int Switch;




    public void CameraSwitch()
    {
        Switch++;
        if (Switch > cameraSwitchView.Length) { Switch = 0; }
    }



    void Update()
    {


        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }



//        var VScript = (VehicleControl)target.GetComponent<VehicleControl>();
//        GetComponent<Camera>().fieldOfView = Mathf.Clamp(VScript.speed / 10.0f + 60.0f, 60, 90.0f);


        // add MotionBlur effect to camera

        /*
        if (VScript.curTorque == VScript.carSetting.shiftPower)
        {
            transform.GetComponent<MotionBlur>().blurAmount = Mathf.Lerp(transform.GetComponent<MotionBlur>().blurAmount, 1.0f, Time.deltaTime * 5);
        }
        else
        {
            transform.GetComponent<MotionBlur>().blurAmount = Mathf.Lerp(transform.GetComponent<MotionBlur>().blurAmount, 0.0f, Time.deltaTime);
        }
        */
        

        

        if (Input.GetKeyDown(KeyCode.C))
        {
            Switch++;
            if (Switch > cameraSwitchView.Length) { Switch = 0; }
        }



        if (Switch == 0)
        {
            // Damp angle from current y-angle towards target y-angle



			float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y,target.eulerAngles.y+(yRotation), ref yVelocity, smooth);
            float xAngle =  Mathf.SmoothDampAngle(transform.eulerAngles.x,target.eulerAngles.x + (Angle), ref xVelocity, smooth);

            // Look at the target
            transform.eulerAngles = new Vector3(Angle, yAngle, 0.0f);

            var direction = transform.rotation * -Vector3.forward;
            var targetDistance = AdjustLineOfSight(target.position + new Vector3(0, height, 0), direction);


            transform.position = target.position + new Vector3(0, height, 0) + direction * targetDistance;


        }
        else
        {

            transform.position = cameraSwitchView[Switch - 1].position;
            transform.rotation = Quaternion.Lerp(transform.rotation, cameraSwitchView[Switch - 1].rotation, Time.deltaTime * 5.0f);

        }


    }



    float AdjustLineOfSight(Vector3 target, Vector3 direction)
    {


        RaycastHit hit;

        if (Physics.Raycast(target, direction, out hit, distance, lineOfSightMask.value))
            return hit.distance;
        else
            return distance;

    }


}
