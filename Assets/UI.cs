using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour {


    public Text tex;
    private float num;
    void Update() {
        if (GameManagerScript.Instance.GetRotate() == true)
        {
            tex.text = "90";
        }
        else
        {
            tex.text = "0";
        }
	}
}
