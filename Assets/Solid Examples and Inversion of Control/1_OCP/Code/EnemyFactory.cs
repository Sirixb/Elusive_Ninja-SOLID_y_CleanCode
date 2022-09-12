using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    //[SerializeField] private GameObject warrior;
    //[SerializeField] private GameObject archer;

    [SerializeField] private Enemy[] enemies;
    private Dictionary<string, Enemy> idToEnemies = new Dictionary<string, Enemy>();

    private void Awake()
    {
        foreach (var enemy in enemies)
        {
            idToEnemies.Add(enemy.Id, enemy);
        }
    }

    public Enemy /*GameObject*/ Create(string enemyId/*EnemyTypes enemyTypeToSpawn*/)
    {
        //Enemy enemyToSpawn;
        if (!idToEnemies.TryGetValue(enemyId, out var enemyToSpawn))
        {
            throw new ArgumentOutOfRangeException();
        }
        //switch (enemyTypeToSpawn)
        //{
        //    case EnemyTypes.Warrior:
        //        return Instantiate(warrior);
        //    case EnemyTypes.Archer:
        //        return Instantiate(archer);
        //    default:
        //        throw new ArgumentOutOfRangeException();
        //}

        return Instantiate(enemyToSpawn);
    }
}
