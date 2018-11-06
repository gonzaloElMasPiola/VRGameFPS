using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    Collider m_Collider;
    Vector3 m_Size;
    private float aux;
	void Start () {
        m_Collider = GetComponent<Collider>();
        m_Size = m_Collider.bounds.size;
        aux = GameManagerScript.Instance.GetWall();
        GameManagerScript.Instance.SetWallY(m_Size.y/2);
        transform.localScale = new Vector3(aux, transform.localScale.y , aux/2);
        Debug.Log(m_Size);
    }
	
	void Update () {
		
	}
}
