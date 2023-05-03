using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistenceData : MonoBehaviour
{
    public static PersistenceData instance;

    public string playerName;
    public int highScore;

    private void Awake()
    {
        if (PersistenceData.instance != null)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        Load();
    }


    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            highScore = data.highScore;
        }
    }
}
