using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stage {     
    public EnemySpawnInfo[] enemies;
}

[System.Serializable]
public class EnemySpawnInfo
{    
    public EnemyFactory.EnemyType Prefab; //esto un enum del factory
    public int Count;    
}
