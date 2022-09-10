using UnityEngine;

/* Manage the state of the game */
public class GameEventListener : MonoBehaviour
{
    public static GameEventListener Instance { get; private set; }

    [SerializeField] private MainMenu _menu;
    [SerializeField] private ObstacleSpawner _obstacleManager;
    [SerializeField] private /*DavidSolution.*/ItemsSpawner _itemsManager;
    [SerializeField] private Player _player;

    private ISaver _save;

    private float _gamStartTime;

    //[SerializeField] private PlayerPrefsPersistence _persistence;

    private void Awake()
    {
        //_save = new PlayerPrefsPersistence();
        Instance = this;
    }
    
    public void Configure(ISaver save)
    {
        _save = save;
    }

    public void OnPlayerDeath()
    {
        _obstacleManager.DestroyProjectiles();
        _itemsManager.DestroyItems();
        var gameDuration = Time.time - _gamStartTime;
        // Save the last duration
        //var persistence = new Persistence();
        //persistence.SaveLastDuration(duration);
        _save.SaveData(gameDuration);

        //Intentos mios por resolver ISP pero no lo consegui: persistencia la habia puesto heredar de monobehaviour
        //persistence.GetComponent<ISave>().SaveLastDuration(duration);
        //GameObject.FindObjectOfType<Persistence>().GetComponent<ISave>().SaveLastDuration(duration);

        //PlayerPrefs.SetFloat("duration", duration);
        //PlayerPrefs.Save();

        //_persistence.SaveTime();//David Solution
        _menu.ShowGameOver();
    }

    public void OnStartGame()
    {
        // Start timer
        _gamStartTime = Time.time;
        // Start the logic of the managers and reset the player
        _obstacleManager.StartSpawning();
        _itemsManager.StartSpawning();
        _player.Reset();
    }
}
