using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    static HUDManager instance = null;
    public Text baseHPText;
    public Text enemiesRemainingText;
    public int baseHP;
    public int enemiesRemaining;

    public static HUDManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<HUDManager>();

            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }


    void Update () {
        baseHPText.text = "Base HP: " + baseHP.ToString() ;
        enemiesRemainingText.text = "Enemies Remaining: " + enemiesRemaining.ToString();

    }

    public void GetBaseHP(int _baseHP)
    {
        baseHP = _baseHP;
    }

    public void GetEnemiesRemaining(int _enemiesRemaining)
    {
        enemiesRemaining = _enemiesRemaining;
    }
}
