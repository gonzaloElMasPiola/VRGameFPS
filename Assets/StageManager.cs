using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance = null;

    public enum States
    {
        Idle,
        Spawn,
    }

    [SerializeField] Stage[] stages;

    public States currentState;

    Timer timer = new Timer(1.0f);

    private int enemiesSpawned;
    private int stage;
    private int id;
   
    private Vector3 spawnerPosition;    

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        id = 0;
        currentState = States.Idle;
        DontDestroyOnLoad(instance);
    }

    private void Update()
    {
        switch (currentState)
        {
            case States.Spawn:
                timer.Start();
                StageSpawn();
                break;

            case States.Idle:
                timer.Reset();
                id = 0;
                break;
        }

        //Debug.Log(currentState);
    }

    public void SpawnEnemies(int _stage, Vector3 _spawnerPosition)
    {
        stage = _stage;
        spawnerPosition = _spawnerPosition;
        SetCurrentState(States.Spawn);
    }

    public void StageSpawn()
    {
        if (id < stages[stage].enemies.Length)
        {
            if (timer.Update(Time.deltaTime))
            {
                if (stages[stage].enemies[id].Count != 0)
                {
                    Instantiate(stages[stage].enemies[id].Prefab, spawnerPosition, Quaternion.identity);
                    enemiesSpawned++;
                    timer.Reset();
                    timer.Start();
                    stages[stage].enemies[id].Count--;
                }
                else
                id++;
            }
        }
        else
            SetCurrentState(States.Idle);        
    }

   public void SetCurrentState(States _state)
    {
        currentState = _state;
    }

    public int ReturnEnemiesSpawned()
    {
        return enemiesSpawned;
    }

   

}


