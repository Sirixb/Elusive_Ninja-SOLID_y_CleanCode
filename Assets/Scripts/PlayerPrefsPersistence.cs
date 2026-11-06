using UnityEngine;

public class PlayerPrefsPersistence : ILoader, ISaver
{
    private readonly string DurationKey= "duration";

    public float LoadData()
    {
        return PlayerPrefs.GetFloat(DurationKey);
    }

    public void SaveData(float duration)
    {
        PlayerPrefs.SetFloat(DurationKey, duration);
        PlayerPrefs.Save();
    }
}
