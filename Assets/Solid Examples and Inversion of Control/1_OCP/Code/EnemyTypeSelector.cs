using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class EnemyTypeSelector
{
    private List<string> enemyIds;

    public EnemyTypeSelector(List<string> enemyIds)
    {
        this.enemyIds = enemyIds;
    }
    
    public string /*EnemyTypes*/ Select()
    {
      //var enemyTypes = (EnemyTypes[]) Enum.GetValues(typeof(EnemyTypes));
        var randomTypeIndex = Random.Range(0, enemyIds.Count/*enemyTypes.Length*/);
        return enemyIds/*enemyTypes*/[randomTypeIndex];
    }
}
