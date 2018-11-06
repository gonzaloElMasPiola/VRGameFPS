using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class GameManagerScript : MonoBehaviour
{
    public int lives;
    public bool Rotate;
    public bool On;
    public bool build;
    public float Wall;
    public float WallY;
    public Vector3 planePosition;
    static GameManagerScript instance = null;
    public NavMeshSurface surface;
    public static GameManagerScript Instance
    {
        get
        {
            if (instance == null)            
                instance = FindObjectOfType<GameManagerScript>();
           
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
        lives = 5;
    }

    private void Update()
    {
        if (lives <= 0)        
            SceneManager.LoadScene("GameOverMenu");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            surface.BuildNavMesh();
        }
        
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
