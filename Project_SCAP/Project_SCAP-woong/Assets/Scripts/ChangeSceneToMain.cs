using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneToMain : MonoBehaviour
{
    //Rigidbody rigid;
    GameObject Player;

    void Awake()
    {
        Player = GameObject.Find("Player");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            SceneManager.LoadScene("SampleScene");
            /*
            Vector3 originPoint = new Vector3();
            originPoint.x = originPoint.x;
            originPoint.y = originPoint.y;
            originPoint.z = originPoint.z;

            Player.transform.position = originPoint;
            */
        }
    }

    void OnTriggerExit(Collider other)
    {

    }
}
