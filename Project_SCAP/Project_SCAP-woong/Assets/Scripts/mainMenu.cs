using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private  IEnumerator WaitforSceneLoad()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnclickNewGame()
    {
        //Debug.Log("start");
        //SceneManager.LoadScene(0);
        StartCoroutine(WaitforSceneLoad());
    }


    public void OnclickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();     
#endif
    }
}
