using UnityEngine;
using System.Collections;
using System;

public class CameraFollowController : MonoBehaviour
{
    private float maxDelta = 90; // (orig: 4)
    private float dampTime = 0.15f; //(orig: 0.35f)  offset from the viewport center to fix damping
    private Vector3 velocity = Vector3.zero;
    
    private GameObject playerShip;
    private Transform cameraAnchor;
    private float StandardZOffset = 0;
    public bool UseForwardLookAt = true;
    public bool LimitCameraDistance = false;

    private static bool paused = false;

    private Vector3 shakeOffset = new Vector3();

    private Vector3 lastTargetPos;

	// Use this for initialization
	void Start ()
	{
		playerShip = GameDataScript.PlayerShip;
		
		if (playerShip != null)
		{
			Debug.Log("Aquired Playership @ Start()");
            cameraAnchor = playerShip.transform.Find("CameraAnchor");
            if (cameraAnchor == null)
            {
//                Debug.LogWarning("Camera Anchor not found!");
            }

			StandardZOffset = transform.position.z;
        }
		else
		{
			Debug.Log("Playership not found @ Start()");
		}
	}

    private static Vector3 offset = new Vector3(0, 0, 0);


    public void reAquireTarget(GameObject target_)
    {
        playerShip = target_;

        Debug.Log("Re-aquiring Playership!");

        if (playerShip != null && target_ != null)
        {

            cameraAnchor = playerShip.transform.Find("CameraAnchor");
            if (cameraAnchor == null)
            {
////                Debug.LogWarning("Camera Anchor not found!");
				Debug.Log("PlayerShip @ "+playerShip.transform.position);
            }
            else
            {
//				Debug.Log("PlayerShip @ "+playerShip.transform.position+", CameraAnchor @ "+cameraAnchor.transform.position);
            }

			StandardZOffset = transform.position.z;
        }
        else
        {
            Debug.LogWarning("Playership not found");
        }
    }


    void LateUpdate()
    {
		if (playerShip == null)
		{
			if (GameDataScript.PlayerShip != null)
				reAquireTarget(GameDataScript.PlayerShip);
			
		}

        // TEST CAMERA SHAKE
        if (Input.GetKeyDown("q"))
        {
            TriggerCamShake();
        }
		// Camera Zoom
		if (Input.GetKey("z"))
		{
			StandardZOffset+=2;
			if (StandardZOffset > 200)
			{
				StandardZOffset = 200;
			}
			
			Debug.Log("StandardZOffset = "+StandardZOffset);
		}
		else if (Input.GetKey("x"))
		{
			StandardZOffset-=2;
			if (StandardZOffset < 20)
			{
				StandardZOffset = 20;
			}
			Debug.Log("StandardZOffset = "+StandardZOffset);
		}



        shakeCam();
    }



// Update is called once per frame
	void Update ()
	{
        if (!playerShip || paused)
        {
            return;
        }


        float myDampTime = dampTime;
        if (LimitCameraDistance)
        {

            float speed = Math.Abs(Vector3.Dot(playerShip.GetComponent<Rigidbody2D>().velocity, -playerShip.transform.up) / 350);

            //Debug.Log("SpeedForward = " + speed);
            //Debug.DrawLine(target.transform.position, target.transform.position + (-target.transform.up * 40), Color.red);


            if (speed > 1)
            {
                speed = 1;
            }

            myDampTime = 0.30f - (0.18f * speed);
        }
		float speed2 = Math.Abs(Vector3.Dot(playerShip.GetComponent<Rigidbody2D>().velocity, -playerShip.transform.up) / 350);
//		Debug.Log("SpeedForward = " + speed2);




        Vector3 delta = playerShip.transform.position - transform.position;
        if (cameraAnchor != null)
        {
            delta = cameraAnchor.position - transform.position;
        }

		float deltaTest = Math.Abs(delta.y);
		delta.z = 0;
	    Vector3 destination = transform.position + delta;

        if (deltaTest > maxDelta)
		{
            deltaTest = deltaTest - maxDelta;
			destination.z = StandardZOffset - deltaTest * 1.0f + speed2 * 20.0f;
		}
		else
        {
			destination.z = StandardZOffset + speed2 * 20.0f;
		}
			
	    transform.position = Vector3.SmoothDamp(transform.position, destination,ref velocity, myDampTime) + offset;
			
//			Debug.Log("Delta = "+delta);

		
	    // Aim at the ship
        if (UseForwardLookAt)
        {
            //Vector3 lookAtPos = target.transform.position;// *target.transform.forward;
            //Quaternion lookRot = Quaternion.LookRotation(lookAtPos - transform.position, target.transform.forward);
            //transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, Time.deltaTime * 10);

            transform.LookAt(playerShip.transform, playerShip.transform.forward);
        }
        else
        {
//            transform.LookAt(playerShip.transform);
        }

        transform.position += shakeOffset;
	}


    private static bool doShake = false;
    private static float shakeTimestamp = 0;
    private const float shakeTime = 0.36f;//0.34f;

    public static void TriggerCamShake()
    {
        Debug.Log("TriggerShake");
        doShake = true;
        shakeTimestamp = Time.time;
    }


    private void shakeCam()
    {
        if (!doShake)
            return;

        float time = Time.time;
        float nextTime = shakeTimestamp + shakeTime;

        if ((nextTime) < time)
        {
            doShake = false;
            shakeOffset = new Vector3();
            return;
        }


        // Run a sinusfunction that starts of
        const float periods = 24;
        float timeLerp = ((nextTime - time) / shakeTime);
        float amplitude = 1.5f * timeLerp * Mathf.Sin(timeLerp * periods);
        shakeOffset.x = amplitude;
        shakeOffset.y = amplitude;
        shakeOffset.z = -amplitude*2.5f;



//        Debug.Log("SHAKE CAM. timeLeft = " + timeLerp + ", amplitude = " + amplitude);
    }


    public static void PauseGame(bool pause)
    {
        paused = pause;
    }
	
}
