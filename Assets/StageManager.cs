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
    Timer timer = new Timer(0.0f);
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
                    Debug.Log("entre aca");
                    EnemyFactory.Instance.CreateEnemy(stages[stage].enemies[id].Prefab, spawnerPosition);
                    timer.Reset(1.0f);
                    timer.Start();
                    stages[stage].enemies[id].Count--;                    
                    HUDManager.Instance.UpdateEnemiesRemaining(EnemyFactory.Instance.AmountOfEnemiesInScene());
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

}


