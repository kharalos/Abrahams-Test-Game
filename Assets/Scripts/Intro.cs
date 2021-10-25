using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Intro : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI warningDisplay;
    string introText;
    void Start()
    {
        introText = "<color=red>Warning!</color>\nThis game may contain religious and mythological elements that some may found offensive.";
        warningDisplay.text = introText;
        warningDisplay.alpha = 0f;
        StartCoroutine(AlphaChanger());
    }
    IEnumerator AlphaChanger()
    {
        yield return new WaitForSecondsRealtime(1f);
        for (int i = 0; i < 100; i++) {
            warningDisplay.alpha += 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        yield return new WaitForSecondsRealtime(4f);
        for (int i = 0; i < 100; i++)
        {
            warningDisplay.alpha -= 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        SceneManager.LoadScene(1);
    }
}
