using UnityEngine;
using System.IO;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public SaveData data = new SaveData();

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class SaveData
    {
        //УРАААААААААААА
    public int score = 0;
    public string namePlayer = "Name";
    }

    public void SaveBestScore(int score)
    {
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "saveFile.json",json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "saveFile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(json);
        }
    }
}
