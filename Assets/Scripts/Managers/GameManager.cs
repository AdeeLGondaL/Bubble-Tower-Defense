using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private List<EnemyGroup> enemyGroups = new List<EnemyGroup>();
    public int score;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        GameUIManager.Instance.SetScore(this.score.ToString());
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

    public void RegisterEnemyGroup(EnemyGroup enemyGroup)
    {
        enemyGroups.Add(enemyGroup);
    }

    public void EnemyGroupDefeated(EnemyGroup enemyGroup)
    {
        enemyGroups.Remove(enemyGroup);

        if (enemyGroups.Count == 0)
        {
            GameWon();
        }
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
