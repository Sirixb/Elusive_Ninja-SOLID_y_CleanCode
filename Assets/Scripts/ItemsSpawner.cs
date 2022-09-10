using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemsSpawner : MonoBehaviour
{
    //public enum ItemTypes
    //{
    //    PermanentSpeed,
    //    Heal
    //}
    [SerializeField] private string[] _itemIds;
    //[SerializeField] private SpeedItem _speedItem;
    //[SerializeField] private HealItem _healItem;

    [SerializeField] private AbstractItems[] _prefabItems;
    private Dictionary<string, AbstractItems> _idToItemsPrefabs;

    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private float _minSpawnInterval = 2;
    [SerializeField] private float _maxSpawnInterval = 4;
    

    private List<GameObject> _spawnedItems = new List<GameObject>();
    private bool _isSpawnAvailable;
    private float _timeToNextSpawn;

    private void Awake()
    {
        _idToItemsPrefabs = new Dictionary<string, AbstractItems>();
        foreach (var prefabItem in _prefabItems)
        {
            _idToItemsPrefabs.Add(prefabItem.Id, prefabItem);
        }
    }
    private void Start()
    {
        CalculateTimeToNextSpawn();
    }
    
    private void Update()
    {
        if (_isSpawnAvailable)
        {
            _timeToNextSpawn -= Time.deltaTime;
            if (_timeToNextSpawn < 0)
            {
                CalculateTimeToNextSpawn();
                // Get random item to spawn
                SpawnItem(/*(ItemTypes)*/ _itemIds[ Random.Range(0, _itemIds/*Enum.GetNames(typeof(ItemTypes))*/.Length)]);
            }
        }
    }
    private void CalculateTimeToNextSpawn()
    {
        _timeToNextSpawn = Random.Range(_minSpawnInterval, _maxSpawnInterval);
    }

    private void SpawnItem(string id/*ItemTypes type*/)
    {
        // Spawn the items in random position
        //switch (type)
        //{
        //    case ItemTypes.PermanentSpeed:
        //        _items.Add(Instantiate(_speedItem,
        //                               _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)].transform.position,
        //                               Quaternion.identity).gameObject);
        //        break;
        //    case ItemTypes.Heal:
        //        _items.Add(Instantiate(_healItem,
        //                               _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)].transform.position,
        //                               Quaternion.identity).gameObject);
        //        break;
        //    default:
        //        throw new ArgumentOutOfRangeException(nameof(type), type, null);
        //}
        AbstractItems itemToInstantiate;
        if (!_idToItemsPrefabs.TryGetValue(id, out itemToInstantiate))
        {
            throw new ArgumentOutOfRangeException();
        }

        _spawnedItems.Add(Instantiate(itemToInstantiate,
                _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)].transform.position,
                Quaternion.identity).gameObject);
    }

    public void DestroyItems()
    {
        foreach (var projectile in _spawnedItems)
        {
            Destroy(projectile);
        }

        _isSpawnAvailable = false;
    }
    
    public void StartSpawning()
    {
        _isSpawnAvailable = true;
    }
}
