using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }

    //what need to be save
    public int currentPlayer;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
            instance = this;


        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerIndo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerIndo.dat", FileMode.Open);
            PlayerDataStorage data = (PlayerDataStorage)bf.Deserialize(file);

            currentPlayer = data.currentPlayer;
            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerIndo.dat");
        PlayerDataStorage data = new PlayerDataStorage();

        data.currentPlayer = currentPlayer;

        bf.Serialize(file, data);
        file.Close();
    }

    [Serializable] class PlayerDataStorage
    {
        public int currentPlayer;
    }


}
