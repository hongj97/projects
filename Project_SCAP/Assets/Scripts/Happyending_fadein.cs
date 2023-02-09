using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Happyending_fadein : MonoBehaviour
{

    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    // public void Fade()
    //{
    //   StartCoroutine(fade());
    // }

    IEnumerator fadein()
    {
        //yield return new WaitForSeconds(3);
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null;
    }

    
    /*
    void OnTriggerEnter(Collider other)
    {
        // SceneManager.LoadScene(2);
        StartCoroutine(fade());
     
    }
    */

    void Start()
    {
        
        StartCoroutine(fadein());
        
    }

}
