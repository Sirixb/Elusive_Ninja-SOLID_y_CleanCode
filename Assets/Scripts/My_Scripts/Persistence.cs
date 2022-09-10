using System;
using UnityEngine;
using UnityEngine.UI;

namespace DavidSolution
{

public class Persistence: MonoBehaviour
{
    private float _startTime;

    public void SaveTime()
    {
        var duration = Time.time - _startTime;
        // Save the last duration
        PlayerPrefs.SetFloat("duration", duration);
        PlayerPrefs.Save();

    }
    
    public string LoadTime()
    {
        // Get the last time and format it
        var time = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("duration"));
        return time.ToString(@"mm\:ss"); 
    }
}

}
