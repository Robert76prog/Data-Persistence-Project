using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static DataManager Instance;
    public string PlayerName;
    public string TopPlayerName;
    public int Highscore;
    public int Score;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }


    [System.Serializable]
    class GameData
    {
        public string PlayerName;
        public string TopPlayerName;
        public int Highscore;
    }

    public void SaveData()
    {
        GameData data = new GameData();
        //current Player
        data.PlayerName = PlayerName;
        data.Highscore = Highscore;
        data.TopPlayerName = TopPlayerName;
        
        //Hihgscore topped?
        if (Score > data.Highscore)
        {
            data.Highscore = Score;
            Highscore = Score;
            data.TopPlayerName = PlayerName;
            TopPlayerName = PlayerName;
        }

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);

            PlayerName = data.PlayerName;
            TopPlayerName = data.TopPlayerName;
            Highscore = data.Highscore;

        }
    }

}
