using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            if (SceneManager.GetActiveScene().buildIndex != 2) Destroy(Instance.gameObject);
            Destroy(gameObject);
            return;
        }
        // end of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
