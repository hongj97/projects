using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changeretry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Change", 4);
    }
    void Change()
    {
        SceneManager.LoadScene("retryscene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
