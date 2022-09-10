using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DavidSolution
{

public class ItemsManager : MonoBehaviour
{
    //public enum ItemTypes
    //{
    //    PermanentSpeed,
    //    Heal
    //}
    //[SerializeField] private SpeedItem _speedItem;
    //[SerializeField] private HealItem _healItem;

      
    //[SerializeField] private List<string> itemIds;
    
    [SerializeField] private Item[] items;
    private Dictionary<string, Item> idToItems = new Dictionary<string, Item>();

    private void Awake()
    {
        foreach (var item in items)
        {
             idToItems.Add(item.Id, item);
        }   
    }


    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private float _minSpawnInterval = 2;
    [SerializeField] private float _maxSpawnInterval = 4;
    
    private List<GameObject> _items = new List<GameObject>();
    private bool _canSpawn;
    private float _timeToNextSpawn;

    private void Start()
    {
        CalculateTimeToNextSpawn();
    }
    
    private void Update()
    { 
        if (_canSpawn)
        {
            _timeToNextSpawn -= Time.deltaTime;
            if (_timeToNextSpawn < 0)
            {
                CalculateTimeToNextSpawn();
                // Get random item to spawn
                var randomTypeIndex = Random.Range(0, items.Length /*itemIds.Count*/);
                SpawnItem(/*itemIds*/items[randomTypeIndex].Id/*(ItemTypes) Random.Range(0, Enum.GetNames(typeof(ItemTypes)).Length)*/);
            }
        }
    }
    private void CalculateTimeToNextSpawn()
    {
        _timeToNextSpawn = Random.Range(_minSpawnInterval, _maxSpawnInterval);
    }

    private Item/*void*/ SpawnItem(string itemId/*ItemTypes type*/)
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

            if (!idToItems.TryGetValue(itemId, out var itemToSpawn))
            {
                throw new ArgumentOutOfRangeException();
            }

            return Instantiate(itemToSpawn/*, _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)].transform.position, Quaternion.identity).gameObject*/);
    }

    public void DestroyItems()
    {
        foreach (var projectile in _items)
        {
            Destroy(projectile);
        }

        _canSpawn = false;
    }
    
    public void StartSpawning()
    {
        _canSpawn = true;
    }
}

}
