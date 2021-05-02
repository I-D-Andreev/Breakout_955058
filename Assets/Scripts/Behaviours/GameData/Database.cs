using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DatabaseBehaviour : MonoBehaviour
{
    private static DatabaseBehaviour _classInstance;
    private string _gameDataPath;
    private GameData _gameData;

    private void Awake()
    {
        if (_classInstance == null)
        {
            _classInstance = this;
            SetGameDataPath();
            LoadGameData();
            
            DontDestroyOnLoad(gameObject);
        }
        else
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


    private void LoadGameData()
    {
       // todo1: Try/Catch
       // Load empty on corrupted data file
        if (File.Exists(_gameDataPath))
        {
            Debug.Log("Load From File...");
            FileStream stream = new FileStream(_gameDataPath, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            _gameData = formatter.Deserialize(stream) as GameData;
            stream.Close();
        }
        else
        {
            Debug.Log("Start New...");
            _gameData = new GameData();
        }
        
        Debug.Log("Done!");
    }
    
    private void SaveGameData()
    {
        Debug.Log("Saving...");
        string directory = Path.GetDirectoryName(_gameDataPath);
        Directory.CreateDirectory(directory ?? string.Empty);

        FileStream stream = new FileStream(_gameDataPath, FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, _gameData);
        stream.Close();
        
        Debug.Log("Saved!");
    }

    private void SetGameDataPath ()
    {
        _gameDataPath = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "Data", "data.save"));
    }
    
    public GameData GameData => _gameData;
}
