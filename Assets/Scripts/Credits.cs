using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Credits : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI warningDisplay;
    public string[] creditsTexts;
    void Start()
    {
        warningDisplay.alpha = 0f;
        StartCoroutine(AlphaChanger(5f));
    }
    int queue = 0;
    IEnumerator AlphaChanger(float time)
    {
        if (queue >= creditsTexts.Length) queue = 0;
        warningDisplay.text = creditsTexts[queue];
        if (creditsTexts.Length - 1 == queue) time = 60f;
        queue++;
        yield return new WaitForSecondsRealtime(1f);
        for (int i = 0; i < 100; i++) {
            warningDisplay.alpha += 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        yield return new WaitForSecondsRealtime(time);
        for (int i = 0; i < 100; i++)
        {
            warningDisplay.alpha -= 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
        }

        StartCoroutine(AlphaChanger(4f));
    }
    public void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
