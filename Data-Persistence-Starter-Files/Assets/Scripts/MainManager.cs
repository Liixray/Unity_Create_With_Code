using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using System.IO;
using UnityEngine.SocialPlatforms.Impl;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public string playerName; 
    public int playerScore; 

    public string playerHighScoreName; 
    public int playerHighScore;

    private void Awake()
    {
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 

        Load();
        Debug.Log(playerHighScore);
        Debug.Log(playerHighScoreName);
    }

    [System.Serializable]
    class SaveData
    {
        public string playerHighScoreName;
        public int playerHighScore;
    }

    public void Save()
    { 
        SaveData data = new SaveData();
        data.playerHighScoreName = playerHighScoreName;
        data.playerHighScore = playerHighScore;
        string json = JsonUtility.ToJson(data); ;
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerHighScore = data.playerHighScore;
            playerHighScoreName = data.playerHighScoreName;
        }
    }
}
