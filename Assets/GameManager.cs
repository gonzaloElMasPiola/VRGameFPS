using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class GameManager: MonoBehaviour
{
    [SerializeField] public int[] gameModes;
    public int lives;
    public bool Rotate;
    public bool On;
    public bool build;
    public float Wall;
    public float WallY;
    public Vector3 planePosition;
    static GameManager instance = null;
    public NavMeshSurface surface;
    public float timer;
    public float stageDuration;
    public GameObject enemy1;
    public GameObject spawner;
   

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
    }

    private void Update()
    {

        switch (currentState) {
            case State.Build:
                timer += 1.0f * Time.deltaTime;
                if (timer > stageDuration)
                {
                    surface.BuildNavMesh();
                    GoNextState();
                }
                break;
            case State.Spawn:
                StageManager.instance.SpawnEnemies(0, spawner.transform.position);
                GoNextState();
                break;
            case State.Play:

                break;
        }

        if (lives <= 0)        
            SceneManager.LoadScene("GameOverMenu");
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
