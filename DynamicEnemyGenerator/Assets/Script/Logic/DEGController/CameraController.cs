using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private int _viewIndex = 0;
    private Transform _currentView;
    public Transform[] cameraView;
    public float transitionSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _currentView = cameraView[0];    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        ChangeCameraView();
    }

    private void ChangeCameraView()
    {
        transform.position = Vector3.Lerp(transform.position, _currentView.position, Time.deltaTime * transitionSpeed);
        Vector3 currentAngle = new Vector3(
            Mathf.LerpAngle(transform.rotation.eulerAngles.x, _currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.y, _currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.z, _currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));
        transform.eulerAngles = currentAngle;
    }
}
