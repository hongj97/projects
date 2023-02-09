using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class num_key : MonoBehaviour
{
    GameObject obj; 
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Door");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {   
        print("push");
        obj.GetComponent<Door>().input_val(1);
    }
}
