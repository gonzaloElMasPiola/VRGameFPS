using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour {

   
    static EnemyFactory instance = null;
    public GameObject[] enemies;
    public enum EnemyType
    {
        Melee,
        Ranged,   
    }
    EnemyType enemyToSpawn;

    public static EnemyFactory Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<EnemyFactory>();

            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }

   

    public GameObject CreateEnemy(EnemyType _enemyType, Vector3 _spawnPosition)
    {
        GameObject aux;
        switch (_enemyType)
        {
            case EnemyType.Melee:
                aux = Instantiate(enemies[0], _spawnPosition, Quaternion.identity);                
                break;
            case EnemyType.Ranged:
                aux = Instantiate(enemies[1], _spawnPosition, Quaternion.identity);                
                break;
            default:
                aux = null;
                break;

        }
        return aux;

        
    }

   


    //public GameObject Prefab;
    //Una lista gameobjects enemy que tenga cantidad de enemigos para contruir y destuir

}
