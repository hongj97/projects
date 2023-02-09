using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform targetTransform;
    public Vector3 CameraOffset;

    void Update()
    {
        transform.position = targetTransform.position + CameraOffset;

    
        // if(Input.GetMouseButtonDown(0))
        // {
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit hit;
        //     if(Physics.Raycast(ray, out hit))
        //     {
        //         string objname = hit.collider.gameObject.name;
        //         Debug.Log(objname);
        //     }
        // }
    }
}

