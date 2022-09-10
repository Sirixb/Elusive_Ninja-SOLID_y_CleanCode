using UnityEngine;
using System.IO;

public class FilePersistance : ILoader, ISaver
{
    private const string path = "Assets/Resources/saveFile.txt";
    
    public void SaveData(float duration)
    {
        var writer = new StreamWriter(path, true);
        Debug.Log(writer);
        writer.WriteLine(duration);
        writer.Close();
    }
    public float LoadData()
    {
        var reader = new StreamReader(path);
        var durationString = (reader.ReadToEnd());
        reader.Close();

        if (!string.IsNullOrEmpty(durationString))
        {
            return float.Parse(durationString);
        }

        return 0;
    }

}
