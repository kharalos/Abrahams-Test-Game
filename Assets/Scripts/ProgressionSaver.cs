using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ProgressionSaver : MonoBehaviour
{
    public static ProgressionSaver Instance;
    public int level;
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        LoadLevel();
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    class SaveData
    {
        public int level;
    }
    public void ResetAndSaveLevel()
    {
        level = 1;
        SaveLevel();
    }
    public void NewLevel(int levelValue)
    {
        level = levelValue;
        SaveLevel();
    }
    public void SaveLevel()
    {
        SaveData data = new SaveData();
        data.level = level;


        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadLevel()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            level = data.level;
        }
    }
}
