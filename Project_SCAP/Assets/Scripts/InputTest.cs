using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputTest : MonoBehaviour
{
    public InputField passwordInput;
    
    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    IEnumerator fade()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while(alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
    }

    void LockInput(InputField input)
    {
        if(input.text.Length == 0)
        {
            Debug.Log("Main Input Empty");
        }
        else if(input.text == "3740")
        {
            StartCoroutine(fade());
            SceneManager.LoadScene("firstfloor");
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("Wrong");
        }
    }

    public void Start()
    {
        passwordInput.onSubmit.AddListener(delegate{LockInput(passwordInput);});
    }
}
