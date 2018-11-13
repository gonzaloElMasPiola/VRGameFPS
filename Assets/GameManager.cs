using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;
    [SerializeField] public int[] gameModes;
    public int lives;
    public bool Rotate;
    public bool On;
    public bool build;
    public float Wall;
    public float WallY;
    public Vector3 planePosition;    
    public NavMeshSurface surface;
    public float timer;
    public float stageDuration;
    public GameObject enemy1;
    public GameObject spawner;    
    public int stageNumber;
    public int enemiesRemaining;
    public int hP;
    public int baseHP;


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
    State currentState;

    void Awake()
    {
        instance = this;
        lives = 5;
        stageNumber = 0;
        hP = 100;
        baseHP = 100;
        HUDManager.Instance.GetBaseHP(baseHP);
    }

    private void Update()
    {

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
                enemiesRemaining = StageManager.instance.ReturnEnemiesSpawned();
                HUDManager.Instance.GetEnemiesRemaining(enemiesRemaining);
                if (Input.GetKeyDown(KeyCode.L) || enemiesRemaining == 0)
                {
                    StartNextStage();
                }
                break;
        }
        //Debug.Log(currentState);

        if (lives <= 0)
            SceneManager.LoadScene("GameOverMenu");
    }

    public void EnemyHitBase()
    {
        baseHP -= 10;
        HUDManager.Instance.GetBaseHP(baseHP);
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

    public void LoseLife()
    {
        if (lives > 0)
            lives--;
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
}
