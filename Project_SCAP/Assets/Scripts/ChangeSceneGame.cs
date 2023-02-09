using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneGame : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    private IEnumerator WaitforSceneLoad()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(3);
    }

   
   // public void Fade()
    //{
     //   StartCoroutine(fade());
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


    void OnTriggerEnter(Collider other)
    {
        // SceneManager.LoadScene(2);
        StartCoroutine(fade());
        StartCoroutine(WaitforSceneLoad());
    }
}
