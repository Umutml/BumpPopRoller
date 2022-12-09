using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager instance { get; private set; }

    

    [Header("TextObject")]
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI ballText;
    public GameObject startButton;
    public GameObject levelCompleteUI;
    public GameObject levelFailUI;
    [Header("Forces")]
    public float expForce = 30;
    public float constForce = 30;
    [Header("Boost Count")]
    public int SpawnCount = 3;
    [Header("Counters")]
    public int activeBall;
    public static int money = 20; // Start money 30 for test
    public int finishedBall;
    public bool canStart;
    

    void Start()
    {
        activeBall = 6;
        finishedBall = 0;
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);  
        }
        
    }
    void Update()
    {
        ScoreUpdater();
        LevelCompleteCheck();
    }

    private void ScoreUpdater()
    {
        moneyText.text = money.ToString();
        ballText.text = activeBall.ToString();
    }

    private void LevelCompleteCheck()
    {
        if (finishedBall >= 20)
        {
            levelCompleteUI.SetActive(true);
        }
        else
        {
            // LevelFail UI
        }
    }

    public void SpawnCountBoost()
    {
        

        if (money >= 5)
        {
            money -= 5;
            Debug.Log("Spawn Count +1 Boosted: " + SpawnCount);
            SpawnCount++;            // 1+ spawncount
        }
        else
        {
            // Not Enoug Money
        }
        
        
    }
    public void SpawnCountMultiple()
    {
        if (money >= 20)
        {
            money -= 20;
            SpawnCount *= 2;         // x2
            Debug.Log("Spawn Count X2 Boosted: " + SpawnCount);
        }
        else
        {
            // Not Enoug Money
        }

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TouchStart()
    {
        canStart = true;
        startButton.SetActive(false);
    }
}
