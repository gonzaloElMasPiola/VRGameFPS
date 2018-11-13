using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    Collider m_Collider;
    Vector3 m_Size;
    private float aux;
    void Start()
    {
        m_Collider = GetComponent<Collider>();
        m_Size = m_Collider.bounds.size;
        aux = GameManager.Instance.GetWall();
        GameManager.Instance.SetWallY(m_Size.y / 2);
        transform.localScale = new Vector3(aux/2.6f, transform.localScale.y/2.6f, aux/2.6f);
        Debug.Log(m_Size);
    }

    void Update()
    {

    }
}
