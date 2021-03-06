using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    Controller controller;
    bool paused;
    public GameObject pausePanel, deathPanel;
    public GameObject[] spawnPos;
    public GameObject level5;
    public bool hasKnife;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<Controller>();
        controller.DisplayCursor(false);
        Time.timeScale = 1f;
        if (FindObjectOfType<ProgressionSaver>())
        {
            controller.SpawnPosition(spawnPos[ProgressionSaver.Instance.level].transform.position);
            Debug.Log("Spawned at Level " + ProgressionSaver.Instance.level);
            if(ProgressionSaver.Instance.level == 5)
            {
                level5.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause") && !paused)
        {
            Pause();
            pausePanel.SetActive(true);
        }
        else if(Input.GetButtonDown("Pause") && paused && pausePanel.activeInHierarchy)
        {
            ReturnToGame();
        }
    }
    public void ReturnToGame()
    {
        pausePanel.SetActive(false);
        Unpause();
    }
    public void ChaneMouseSensitivity(float value)
    {
        controller.MouseSensitivity = value;
    }
    private void Pause()
    {
        controller.DisplayCursor(true);
        paused = true;
        Debug.Log("Paused");
        Time.timeScale = 0f;
    }
    private void Unpause()
    {
        controller.DisplayCursor(false);
        paused = false;
        Debug.Log("Unpaused");
        Time.timeScale = 1f;
    }
    public void Death()
    {
        deathPanel.SetActive(true);
        controller.m_Dead = true;
        Debug.Log("Died");
        Pause();
    }
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void BadEnding()
    {
        SceneManager.LoadScene(6);
    }
    public void GoodEnding()
    {
        SceneManager.LoadScene(4);
    }
}
