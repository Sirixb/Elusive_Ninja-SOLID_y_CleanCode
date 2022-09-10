using UnityEngine;


public class GameInstaller : MonoBehaviour
{
    [SerializeField] private GameEventListener _gameManager;
    [SerializeField] private MainMenu _menu;

    private void Awake()
    {
        var persistence = new FilePersistance();
        //PlayerPrefsPersistence o FilePersistance
        _gameManager.Configure(GetSavePersistence()/*persistence*/);
        _menu.Configure(GetLoadPersistence()/*persistence*/);
    }

    private ILoader GetLoadPersistence()
    {
        #if UNITY_EDITOR
            return new FilePersistance();
        #endif
            return new PlayerPrefsPersistence();
    }
    private ISaver GetSavePersistence()
    {
        #if UNITY_EDITOR
                return new FilePersistance();
        #endif
                return new PlayerPrefsPersistence();
    }
}
