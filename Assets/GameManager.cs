using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;
    [SerializeField] public int[] gameModes;
    public bool Rotate;
    public bool On;
    public bool build;
    public float Wall;
    public float WallY;
    public string WatBuild = "Wall";
    public Vector3 planePosition;
    public NavMeshSurface surface;
    public float timer;
    public float stageDuration;
    public GameObject enemy1;
    public GameObject spawner;
    public int stageNumber;
    public int hP;
    public int baseHP;
    public int enemiesRemaining;


    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameManager>();
            return instance;
        }
    }

    public enum State
    {
        Build,
        Spawn,
        Play,
    }
    public State currentState;

    void Awake()
    {
        instance = this;
        stageNumber = 0;
        hP = 100;
        baseHP = 100;
        HUDManager.Instance.UpdateBaseHP(baseHP);
        UpdateEnemiesRemaining();
    }

    private void Update()
    {
        Debug.Log("Enemies in scene: " + EnemyFactory.Instance.AmountOfEnemiesInScene());
        switch (currentState)
        {
            case State.Build:
                timer += 1.0f * Time.deltaTime;
                if (timer > stageDuration)
                {
                    surface.BuildNavMesh();
                    GoNextState();
                }
                break;
            case State.Spawn:
                StageManager.instance.SpawnEnemies(stageNumber, spawner.transform.position);
                GoNextState();
                break;
            case State.Play:
                if (enemiesRemaining == 0 || Input.GetKeyDown(KeyCode.L))
                {
                    Debug.Log("cambio de stage");
                    StartNextStage();
                }
                break;
        }
    }

    public void UpdateEnemiesRemaining()
    {
        enemiesRemaining = EnemyFactory.Instance.AmountOfEnemiesInScene();
    }

    public int ReturnEnemiesRemaining()
    {
        return enemiesRemaining;
    }

    public void EnemyHitBase()
    {
        baseHP -= 10;
        HUDManager.Instance.UpdateBaseHP(baseHP);
    }

    public void StartNextStage()
    {
        timer = 0.0f;
        stageNumber++;
        currentState = State.Build;
    }

    void SetCurrentState(State state)
    {
        currentState = state;
    }

    void GoNextState()
    {
        currentState += 1;
    }

    public void GetPlanePosition(Vector3 _planePosition)
    {
        planePosition = _planePosition;
    }
    public void SetPlanePosition(Vector3 _planePosition)
    {
        planePosition = _planePosition;
    }

    public float GetPlanePositionX()
    {
        return planePosition.x;
    }
    public float GetPlanePositionY()
    {
        return planePosition.z;
    }
    public void SetPlaneOn(bool _On)
    {
        On = _On;
    }
    public bool GetPlaneOn()
    {
        return On;
    }
    public void SetBuildOn(bool _build)
    {
        build = _build;
    }
    public bool GetBuildOn()
    {
        return build;
    }
    public void SetRotate(bool _Rotate)
    {
        Rotate = _Rotate;
    }
    public bool GetRotate()
    {
        return Rotate;
    }
    public void SetWall(float _Wall, float _square)
    {
        Wall = _Wall / _square;
    }
    public float GetWall()
    {
        return Wall;
    }
    public void SetWallY(float _WallY)
    {
        WallY = _WallY;
    }
    public float GetWallY()
    {
        return WallY;
    }

    public void SetWatBuild(string _WatBuild)
    {
        WatBuild = _WatBuild;
    }
    public string GetWatBuild()
    {
        return WatBuild;
    }


}
