using UnityEngine;

/* Composition root: decides which implementations are injected into the game */
public class GameInstaller : MonoBehaviour
{
    [SerializeField] private GameEventListener _gameManager;
    [SerializeField] private MainMenu _menu;

    private void Awake()
    {
        _gameManager.Configure(GetSavePersistence());
        _menu.Configure(GetLoadPersistence());
    }

    private ILoader GetLoadPersistence()
    {
#if UNITY_EDITOR
        return new FilePersistance();
#else
        return new PlayerPrefsPersistence();
#endif
    }

    private ISaver GetSavePersistence()
    {
#if UNITY_EDITOR
        return new FilePersistance();
#else
        return new PlayerPrefsPersistence();
#endif
    }
}
