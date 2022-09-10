using System;
using UnityEngine;
using UnityEngine.UI;
/* Start game menu */
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Text _lastGameDurationText;

    //[SerializeField] private Persistence _persistence; David

    private ILoader _load;

    private void Awake()
    {
        //_load = new PlayerPrefsPersistence();
        _startButton.onClick.AddListener(OnStartButtonPressed);
    }

    public void Configure(ILoader load)
    {
        _load = load;
    }
    private void OnEnable()
    {
        //var persistence = new Persistence();
        // Get the last time and format it
        var time = TimeSpan.FromSeconds(_load/*persistence*/.LoadData()/*PlayerPrefs.GetFloat("duration")*/);
        _lastGameDurationText.text = time.ToString(@"mm\:ss");
        
        //_lastDuration.text = _persistence.LoadTime();  //David Solution
    }

    private void OnStartButtonPressed()
    {
        GameEventListener.Instance.OnStartGame();
        gameObject.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameObject.SetActive(true);
    }
}
