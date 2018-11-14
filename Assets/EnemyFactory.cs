using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{


    static EnemyFactory instance = null;
    public GameObject[] typeOfEnemies;
    public List<GameObject> enemiesInScene = new List<GameObject>();
    public enum EnemyType
    {
        Melee,
        Ranged,
    }

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
                aux = Instantiate(typeOfEnemies[0], _spawnPosition, Quaternion.identity);
                enemiesInScene.Add(aux);
                break;
            case EnemyType.Ranged:
                aux = Instantiate(typeOfEnemies[1], _spawnPosition, Quaternion.identity);
                enemiesInScene.Add(aux);
                break;
            default:
                aux = null;
                break;

        }
        return aux;


    }

    public int AmountOfEnemiesInScene()
    {
        return enemiesInScene.Count;
    }

    public void DestroyEnemy(GameObject enemyToDestroy)
    {
        if (enemiesInScene.Contains(enemyToDestroy))
        {
            Debug.Log("Taking enemy from factory list");
            enemiesInScene.Remove(enemyToDestroy);
            Destroy(enemyToDestroy);
        }
    }







}
