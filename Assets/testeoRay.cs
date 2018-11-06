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
                GameManagerScript.Instance.GetPlanePosition(hit.point);
                GameManagerScript.Instance.SetPlaneOn(true);
                // Debug.Log(hit.point);
            }
            else
            {
                GameManagerScript.Instance.SetPlaneOn(false);
            }
        }
        else
        {
            GameManagerScript.Instance.SetPlaneOn(false);
        }
        if(build)
        {
            GameManagerScript.Instance.SetBuildOn(true);
        }
        if (Rotate)
        {
            GameManagerScript.Instance.SetRotate(true);
        }
    }
}
