using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacingBillboard : MonoBehaviour
{
    public Camera m_Camera;
    // Start is called before the first frame update
    void Start()
    {
        m_Camera = GameObject.Find("TPCamera").GetComponent<Camera>();    
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
}
