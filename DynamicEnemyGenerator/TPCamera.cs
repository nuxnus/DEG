using UnityEngine;
using System.Collections;


public class TPCamera : MonoBehaviour
{
    private Transform camNormalPos;
    private Transform camNearPos;
    private Transform camFarPos;
    private Transform camLookUpPos;
    private Transform camFrontPos;
    public float camTransSpeed = 2;

    private int camIndex = 0;
    private float camTransTime = 2;
    private bool camTrans = false;

    public float smooth = 3f;

    // Positions for camera
    //Transform standardPos; 
    //Transform frontPos;
    Transform jumpPos;
    bool bQuickSwitch = false;


    void Start()
    {
        /*standardPos = GameObject.Find ("CamPos").transform;
		frontPos = GameObject.Find ("FrontPos").transform;
		jumpPos = GameObject.Find ("JumpPos").transform;
		transform.position = standardPos.position;	
		transform.forward = standardPos.forward;*/

        camNormalPos = GameObject.Find("camNormalPos").transform;
        camNearPos = GameObject.Find("camNearPos").transform;
        camFarPos = GameObject.Find("camFarPos").transform;
        camLookUpPos = GameObject.Find("camLookUpPos").transform;
        camFrontPos = GameObject.Find("camFrontPos").transform;
        jumpPos = GameObject.Find("JumpPos").transform;
        transform.position = camNormalPos.position;
        transform.rotation = camNormalPos.rotation;
    }

    private void LateUpdate()
    {
        ChangeCameraView();
    }

    void FixedUpdate()
    {
        //ChangeCameraView();
        // Must be in FixedUpdate
        /*if(Input.GetButton("Fire1")) // left Ctlr
		{	
			// Change Front Camera
			setCameraPositionFrontView();
		} else if(Input.GetButton("Fire2"))	//Alt
		{	
			// Change Jump Camera
			setCameraPositionJumpView();
		} else {	
			// return the camera to standard position and direction
			setCameraPositionNormalView();
		}*/
    }

    void setCameraPositionNormalView()
    {
        if (bQuickSwitch == false)
        {
            // the camera to standard position and direction
            transform.position = Vector3.Lerp(transform.position, camNormalPos.position, Time.fixedDeltaTime * smooth);
            transform.forward = Vector3.Lerp(transform.forward, camNormalPos.forward, Time.fixedDeltaTime * smooth);
        }
        else
        {
            // the camera to standard position and direction / Quick Change
            transform.position = camNormalPos.position;
            transform.forward = camNormalPos.forward;
            bQuickSwitch = false;
        }
    }
    void setCameraPositionFrontView()
    {
        // Change Front Camera
        bQuickSwitch = true;
        transform.position = camFrontPos.position;
        transform.forward = camFrontPos.forward;
    }

    void setCameraPositionJumpView()
    {
        // Change Jump Camera
        bQuickSwitch = false;
        transform.position = Vector3.Lerp(transform.position, jumpPos.position, Time.fixedDeltaTime * smooth);
        transform.forward = Vector3.Lerp(transform.forward, jumpPos.forward, Time.fixedDeltaTime * smooth);
    }

    void ChangeCameraView()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        { // or getbutton
            camIndex = camIndex < 4 ? camIndex + 1 : 0;
            Debug.Log(camIndex);
            switch (camIndex)
            {
                case 0: // Normal
                    transform.position = Vector3.Lerp(transform.position, camNormalPos.position, Time.fixedDeltaTime * smooth);
                    transform.forward = Vector3.Lerp(transform.forward, camNormalPos.forward, Time.fixedDeltaTime * smooth);
                    break;
                case 1: // Near
                    transform.position = Vector3.Lerp(transform.position, camNearPos.position, Time.fixedDeltaTime * smooth);
                    transform.forward = Vector3.Lerp(transform.forward, camNearPos.forward, Time.fixedDeltaTime * smooth);
                    break;
                case 2: // Far
                    transform.position = Vector3.Lerp(transform.position, camFarPos.position, Time.fixedDeltaTime * smooth);
                    transform.forward = Vector3.Lerp(transform.forward, camFarPos.forward, Time.fixedDeltaTime * smooth);
                    break;
                case 3: // LookUp
                    transform.position = Vector3.Lerp(transform.position, camLookUpPos.position, Time.fixedDeltaTime * smooth);
                    transform.forward = Vector3.Lerp(transform.forward, camLookUpPos.forward, Time.fixedDeltaTime * smooth);
                    break;
                case 4: // Front
                    transform.position = Vector3.Lerp(transform.position, camFrontPos.position, Time.fixedDeltaTime * smooth);
                    transform.forward = Vector3.Lerp(transform.forward, camFrontPos.forward, Time.fixedDeltaTime * smooth);
                    break;
                default:
                    break;
            }
        }
    }
}
