using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastLine : MonoBehaviour
{
    //[SerializeField] Transform linePos;
    [SerializeField] LineRenderer lineRend;
    Ray ray;
    RaycastHit hit;
    Camera cam;
    

    void Update()
    {
        cam = Camera.main;
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100) && GameManager.instance.canStart)
        {
            lineRend.enabled = true;
            lineRend.SetPosition(0, transform.position);
            hit.point = new Vector3(hit.point.x, hit.point.y, hit.point.z+30);
            lineRend.SetPosition(1, hit.point);
        }
        else
        {
            lineRend.enabled = false;
        }
        
    }
}
