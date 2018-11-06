using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

    Collider m_Collider;
    Vector3 m_Size;
    public  int square;
    public GameObject line;
    public GameObject line2;

    private List<Vector2> grid = new List<Vector2>();
    private float temp;
    private float temp2;
    private int pointX;
    private int pointY;
    private float planeX;
    private float planeY;
    private float[] valuesX;
    private float[] valuesY;
    private float LongSquare;
    private float StartSquare;
    private bool Rotate;

    public GameObject Wall;

    void Start()
    {
        Rotate = false;
        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<Collider>();

        //Fetch the size of the Collider volume
        m_Size = m_Collider.bounds.size;

        LongSquare = m_Size.x / square;
        valuesX = new float[square];
        valuesY = new float[square];
        StartSquare = transform.position.x - (m_Size.x / 2);

        GameManagerScript.Instance.SetWall(m_Size.x,square);

        for (int a = 1; a < square; a++)
        {
            line.transform.position = new Vector3(StartSquare + (LongSquare * a), transform.position.y + 0.01f, transform.position.z);
            Instantiate(line);
            valuesX[a - 1] = StartSquare + (LongSquare * a);

        }
        for (int b = 1; b < square; b++)
        {
            line2.transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, StartSquare + (LongSquare * b));
            Instantiate(line2);
            valuesY[b - 1] = StartSquare + (LongSquare * b);
        }

    }

    void Update() {
        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<Collider>();

        //Fetch the size of the Collider volume
        m_Size = m_Collider.bounds.size;
        planeX = GameManagerScript.Instance.GetPlanePositionX();
        planeY = GameManagerScript.Instance.GetPlanePositionY();
        if(GameManagerScript.Instance.GetBuildOn() == true)
        {
            if (GameManagerScript.Instance.GetPlaneOn() == true)
            {
                Build();
            }
        }
        if (GameManagerScript.Instance.GetPlaneOn() == true)
        {
            //Debug.Log("Cuadro(" + pointX + "," + pointY + ")");
            
            for (int c = 1; c <=square; c++)
            {
                if(planeX > valuesX[c - 1])
                {
                    if(c + 1 < square)
                    {
                        if (planeX < valuesX[c])
                        {
                            pointX = c + 1;
                            c = square;
                        }
                    }
                    else if(c + 1 == square)
                    {
                        pointX = c + 1;
                        c = square;
                    }
                }
                else
                {
                    pointX = c;
                    c = square;
                }
            }
            for (int d = 1; d <= square; d++)
            {
                if (planeY > valuesY[d - 1])
                {
                    if (d + 1 < square)
                    {
                        if (planeY < valuesY[d])
                        {
                            pointY = d + 1;
                            d = square;
                        }
                    }
                    else if (d + 1 == square)
                    {
                        pointY = d + 1;
                        d = square;
                    }
                }
                else
                {
                    pointY = d;
                    d = square;
                }
            }
        }     
    }
    void Build()
    {
        temp = valuesX[pointX - 1] - (valuesX[0] / 2);
        temp2 = valuesY[pointY - 1] - (valuesY[0] / 2);
        Wall.transform.position = new Vector3(temp, GameManagerScript.Instance.GetWallY(), temp2);
        if(GameManagerScript.Instance.GetRotate() != Rotate)
        {
            Wall.transform.Rotate(0,90, 0);
            GameManagerScript.Instance.SetRotate(false);
        }
        Vector2 aux;
        aux = new Vector2((int)temp, (int)temp2);
        if (grid.Contains(aux) == false)
        {
            Debug.Log("hola");
            grid.Add(aux);
            Wall.transform.position = new Vector3(temp, 0.3f, temp2);
            Instantiate(Wall);
        }
        Instantiate(Wall);
        GameManagerScript.Instance.SetBuildOn(false);
    }
    
}
