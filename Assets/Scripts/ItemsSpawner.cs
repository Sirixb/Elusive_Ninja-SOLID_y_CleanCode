using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private string[] _itemIds;

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
                SpawnItem(_itemIds[Random.Range(0, _itemIds.Length)]);
            }
        }
    }

    private void CalculateTimeToNextSpawn()
    {
        _timeToNextSpawn = Random.Range(_minSpawnInterval, _maxSpawnInterval);
    }

    private void SpawnItem(string id)
    {
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
