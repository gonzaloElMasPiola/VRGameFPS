using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testeoRay : MonoBehaviour {
    public GameObject Cube2;
   
    public int distance = 5;

    void Update() {

        bool build = Input.GetKeyDown(KeyCode.E);
        bool Rotate = Input.GetKeyDown(KeyCode.Tab);
        float a;
        float b;
        float c;
        a = Input.mousePosition.x;
        b = Input.mousePosition.y - 20f;
        c = Input.mousePosition.z;
        Vector3 aux = new Vector3(a, b, c);
        Ray ray = Camera.main.ScreenPointToRay(aux);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.cyan);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.gameObject == Cube2)
            {
                GameManager.Instance.GetPlanePosition(hit.point);
                GameManager.Instance.SetPlaneOn(true);
                // Debug.Log(hit.point);
            }
            else
            {
                GameManager.Instance.SetPlaneOn(false);
            }
        }
        else
        {
            GameManager.Instance.SetPlaneOn(false);
        }
        if(build)
        {
            GameManager.Instance.SetBuildOn(true);
        }
        if (Rotate)
        {
            GameManager.Instance.SetRotate(true);
        }
    }
}
