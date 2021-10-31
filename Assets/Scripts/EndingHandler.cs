using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndingHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI warningDisplay;
    public string introText;
    void Start()
    {
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
        yield return new WaitForSecondsRealtime(10f);
        for (int i = 0; i < 100; i++)
        {
            warningDisplay.alpha -= 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        SceneManager.LoadScene(3);
    }
}
