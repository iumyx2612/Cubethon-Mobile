using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{ 
    public static void SaveCoin(CoinData coinData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "coin.Thuong");

        FileStream stream = new FileStream(path, FileMode.Create);

        CoinCollected coinCollected = new CoinCollected(coinData);

        formatter.Serialize(stream, coinCollected);
        stream.Close();
    }

    public static CoinCollected LoadCoin()
    {
        string path = Path.Combine(Application.persistentDataPath, "coin.Thuong");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CoinCollected data = formatter.Deserialize(stream) as CoinCollected;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    
    }
    
}
