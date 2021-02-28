using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static int CurrentLives;

    public static void SaveName(string playerName)
    {
        PlayerPrefs.SetString("playerName", playerName);
    }

    public static void SaveDifficulty(float difficulty)
    {
        PlayerPrefs.SetFloat("difficulty", difficulty);
    }

    public static void SaveMaxLives(int maxLives)
    {
        PlayerPrefs.SetInt("maxLives", maxLives);
    }

    public static void SaveSoundSetting(bool setting)
    {
        if(setting) PlayerPrefs.SetInt("soundSetting", 1);
        else PlayerPrefs.SetInt("soundSetting", 0);
    }

    public static void SaveToJson()
    {
        PlayerData data = new PlayerData();
        string file = "PlayerPrefs.txt";

        data.playerName = PlayerPrefs.GetString("playerName");
        data.difficulty = PlayerPrefs.GetFloat("difficulty");
        data.maxLives = PlayerPrefs.GetInt("maxLives");
        data.soundSetting = PlayerPrefs.GetInt("soundSetting");

        string json = JsonUtility.ToJson(data);

        string path = Application.persistentDataPath + "/" + file;
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
            writer.Flush();
            writer.Close();
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public float difficulty;
    public int maxLives;
    public int soundSetting;
}

