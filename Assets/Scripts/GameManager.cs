using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // singleton
    public static GameManager Instance;
    public string playerName = "";

    public const int EntryCount = 10;
    public List<ScoreEntry> s_Entries = new List<ScoreEntry>();

    private void Awake()
    {
        // singleton
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        LoadScores();
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public struct ScoreEntry
    {
        public string name;
        public int score;

        public ScoreEntry(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public List<ScoreEntry> Entries = new List<ScoreEntry>();
    }

    private void SortScores()
    {
        s_Entries.Sort((a, b) => b.score.CompareTo(a.score));
    }

    private void SaveScores()
    {
        SaveData data = new SaveData();

        data.Entries = s_Entries;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    private void LoadScores()
    {

        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            s_Entries.Clear();

            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            //s_Entries = data.Entries;
            for (int i = 0; i < EntryCount; ++i)
            {
                ScoreEntry entry;
                if(i < data.Entries.Count)
                {
                    entry.name = data.Entries[i].name;
                    entry.score = data.Entries[i].score;
                }
                else
                {
                    entry.name = "";
                    entry.score = 0;
                }
                s_Entries.Add(entry);
            }
            SortScores();
        }
    }

    public ScoreEntry GetEntry(int index)
    {
        return s_Entries[index];
    }

    public void Record(string name, int score)
    {
        if(name == "" || name == null)
        {
            name = "Player";
        }
        s_Entries.Add(new ScoreEntry(name, score));
        SortScores();
        s_Entries.RemoveAt(s_Entries.Count - 1);
        SaveScores();
    }

    public bool isEmpty()
    {
        return !s_Entries.Any();
    }
}
