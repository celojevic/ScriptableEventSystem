using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveManager
{

    public static void Save<T>(string localPath, T data)
    {
        string path = $"{Application.persistentDataPath}/{localPath}.vars";
        string json = JsonUtility.ToJson(data);

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream filestream = File.Create(path);
        binaryFormatter.Serialize(filestream, json);
        filestream.Close();
    }

    public static T Load<T>(string localPath)
    {
        string path = $"{Application.persistentDataPath}/{localPath}.vars";
        
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream filestream = File.Open(path, FileMode.Open);
            T data = (T)binaryFormatter.Deserialize(filestream);
            filestream.Close();

            return data;
        }

        Debug.LogError("Unable to load from: " + localPath);
        return default(T);
    }

}
