using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem
{
    #region Singleton

    private static SaveSystem instance = new SaveSystem();
    public static SaveSystem Instance => instance;
    #endregion

    private SaveSystem() { Load(); }

#if UNITY_EDITOR
    private string Path => Application.dataPath + "/ignore/data.json";
#else
    private string Path => Directory.GetCurrentDirectory() + "/data.json";
#endif

    public SaveData SaveData { get; private set; }

    public void Save()
    {
        string jsonData = JsonUtility.ToJson(SaveData);
        StreamWriter writer = new StreamWriter(Path, false);
        writer.WriteLine(jsonData);
        writer.Flush();
        writer.Close();
    }

    public void Load()
    {
        if (!File.Exists(Path))
        {
            SaveData = new SaveData();
            return;
        }

        StreamReader reader = new StreamReader(Path);
        string jsonData = reader.ReadToEnd();
        SaveData = JsonUtility.FromJson<SaveData>(jsonData);
        reader.Close();
    }
}
