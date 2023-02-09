using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{

    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private  IEnumerator WaitforSceneLoad()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    
   // public void Fade()
    //{
      //  StartCoroutine(fade());
   // }

    IEnumerator fade()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
    }



    public void OnclickNewGame()
    {
        //Debug.Log("start");
        //SceneManager.LoadScene(0);
        StartCoroutine(fade());
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
