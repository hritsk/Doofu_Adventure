using System.IO;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float speed;
}

[System.Serializable]
public class PulpitData
{
    public float min_pulpit_destroy_time;
    public float max_pulpit_destroy_time;
    public float pulpit_spawn_time;
}

[System.Serializable]
public class GameData
{
    public PlayerData player_data;
    public PulpitData pulpit_data;
}

public class GameManager : MonoBehaviour
{
    public string jsonFilePath = "Assets/game_data.json";
    public GameData gameData;

    void Start()
    {
        LoadGameData();
    }

    void LoadGameData()
    {
        if (File.Exists(jsonFilePath))
        {
            string json = File.ReadAllText(jsonFilePath);
            gameData = JsonUtility.FromJson<GameData>(json);

            // Now you can access gameData.player_data and gameData.pulpit_data
        }
    }
}
