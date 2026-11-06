using UnityEngine;

/* Manage the state of the game */
public class GameEventListener : MonoBehaviour
{
    public static GameEventListener Instance { get; private set; }

    [SerializeField] private MainMenu _menu;
    [SerializeField] private ObstacleSpawner _obstacleManager;
    [SerializeField] private ItemsSpawner _itemsManager;
    [SerializeField] private Player _player;

    private ISaver _save;

    private float _gameStartTime;

    private void Awake()
    {
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
        var gameDuration = Time.time - _gameStartTime;
        _save.SaveData(gameDuration);
        _menu.ShowGameOver();
    }

    public void OnStartGame()
    {
        _gameStartTime = Time.time;
        _obstacleManager.StartSpawning();
        _itemsManager.StartSpawning();
        _player.Reset();
    }
}
