using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    static HUDManager instance = null;
    public Text baseHPText;
    public Text enemiesRemainingText;

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
   
    public void UpdateBaseHP(int _baseHP)
    {
        baseHPText.text = "Base HP: " + _baseHP.ToString();
    }

    public void UpdateEnemiesRemaining(int _enemiesRemaining)
    {
        enemiesRemainingText.text = "Enemies Remaining: " + _enemiesRemaining.ToString();
    }

   
}
