using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Database : MonoBehaviour
{
    private static Database _classInstance;
    private static GameData _gameData;
    private static string _gameDataPath;

    // public static GameData GameData
    // {
    //     get
    //     {
    //         if (_classInstance == null)
    //         {
    //             GameObject gameObj = new GameObject("Database");
    //             gameObj.AddComponent<Database>();
    //         }
    //
    //         return _gameData;
    //     }
    // }

    public static GameData GameData
    {
        get
        {
            if (_classInstance == null)
            {
                GameObject gameObj = new GameObject("Database");
                gameObj.AddComponent<Database>();
                // Awake called.   
            }

            return _gameData;
        }
    }


    private void Awake()
    {
        if (_classInstance == null)
        {
            _classInstance = this;
            SetGameDataPath();
            LoadGameData();
            DontDestroyOnLoad(gameObject);
        }
        else if (_classInstance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (_classInstance == this)
        {
            SaveGameData();
        }
    }
    

    private static void LoadGameData()
    {
       // todo1: Try/Catch
       // Load empty on corrupted data file
        if (File.Exists(_gameDataPath))
        {
            // Debug.Log("Load From File...");
            FileStream stream = new FileStream(_gameDataPath, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            _gameData = formatter.Deserialize(stream) as GameData;
            stream.Close();
        }
        else
        {
            // Debug.Log("Start New...");
            _gameData = new GameData();
        }
        
        // Debug.Log("Done!");
    }
    
    private static void SaveGameData()
    {
        // Debug.Log("Saving...");
        string directory = Path.GetDirectoryName(_gameDataPath);
        Directory.CreateDirectory(directory ?? string.Empty);

        FileStream stream = new FileStream(_gameDataPath, FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, _gameData);
        stream.Close();
        
        // Debug.Log("Saved!");
    }

    private static void SetGameDataPath ()
    {
        _gameDataPath = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "Data", "data.save"));
    }
}
