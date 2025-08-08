using System;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string CharID ="C01";
    public string Name  ="Player";
    public int HP = 100;
    public int Attack = 15;
    
    public int score;
}

public class SaveDataFile : MonoBehaviour
{
    private int score;
    private string savePath;

    private void Start()
    {
        savePath = System.IO.Path.Combine(Application.dataPath, "SaveDataFile.json");

        Load();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score++;
            Debug.Log(score.ToString());

            Save();
        }
    }

    private void Save()
    {
        SaveData data = new SaveData();
        data.score = score;

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(savePath, json);
    }

    private void Load()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            this.score = data.score;
        }

        else
        {
            score = 0;
        }
    }
}
