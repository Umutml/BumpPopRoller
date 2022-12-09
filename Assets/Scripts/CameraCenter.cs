using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenter : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;
    public GameObject vcamObj;
    

    private void Update()
    {
        if (virtualCam.Follow == null)
        {
            Vector3 vcamObj = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            vcamObj.x = 0;
            vcamObj.y = 25;
            transform.position = vcamObj;
        }
    }

}
