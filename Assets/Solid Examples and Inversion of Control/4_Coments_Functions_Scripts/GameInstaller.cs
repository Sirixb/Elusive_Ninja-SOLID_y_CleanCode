using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private GameEventListener _gameEventListener;

        private void Awake()
        {
            _gameEventListener.Configure(GetLoader(), GetSaver());
        }

        public ILoader GetLoader()
        {
#if UNITY_EDITOR
            return new FilePersistance();
#else
            return new PlayerPrefsPersistence();
#endif
        }

        public ISaver GetSaver()
        {
#if UNITY_EDITOR
            return new FilePersistance();
#else
            return new PlayerPrefsPersistence();
#endif
        }
    }
}
