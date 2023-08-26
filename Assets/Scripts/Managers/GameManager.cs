using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score, numberOfRemainingEnemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        GameUIManager.Instance.SetScore(this.score.ToString());
    }

    private void Update()
    {
        if (numberOfRemainingEnemies <= 0)
        {
            GameWon();
            numberOfRemainingEnemies = 1;
        }
    }

    private void EnemyGroup_OnAllEnemiesKilled(object sender, System.EventArgs e)
    {
        GameWon();
    }

    public void GameWon()
    {
        GameUIManager.Instance.GameWon();
    }

    public void GameLost()
    {
        GameUIManager.Instance.GameLost();
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncrementScore(int scoreIncrement)
    {
        this.score += scoreIncrement;
        Debug.Log(scoreIncrement);
        GameUIManager.Instance.SetScore(this.score.ToString());
    }
    
    #region Singleton

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(Instance);
        }

        Instance = this;
    }

    #endregion
}
