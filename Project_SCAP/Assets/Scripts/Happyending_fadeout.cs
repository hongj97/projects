using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Happyending_fadeout : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    private IEnumerator WaitforSceneLoad()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Happy_ending_2");
    }


    IEnumerator fadeout()
    {
        yield return new WaitForSeconds(4);
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


    void Start()
    {   
        StartCoroutine(fadeout());
        StartCoroutine(WaitforSceneLoad());
    }

}
