using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [Header("In Game UI")]
    
    [SerializeField] private GameObject joystick;
    [SerializeField] private GameObject crossHair;
    [SerializeField] private GameObject inGameUI;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameWonPopup;
    [SerializeField] private GameObject gameLostPopup;
    [SerializeField] private TextMeshProUGUI gameLostScore;
    [SerializeField] private TextMeshProUGUI gameWonScore;
    [SerializeField] private Image colorImage;
    [SerializeField] private GameObject leanTouch;

    [Header("Main Menu UI")]
    
    [SerializeField] private GameObject mainMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        inGameUI.SetActive(true);
    }

    public void SetScore(string score)
    {
        gameWonScore.text = gameLostScore.text = scoreText.text = score;
    }

    public void GameWon()
    {
        joystick.SetActive(false);
        crossHair.SetActive(false);
        leanTouch.SetActive(false);
        gameWonPopup.SetActive(true);
    } 
    
    public void GameLost()
    {
        joystick.SetActive(false);
        crossHair.SetActive(false);
        leanTouch.SetActive(false);
        gameLostPopup.SetActive(true);
    }

    public void SetColor(Color color)
    {
        colorImage.color = color;
    }

    #region Singleton

    public static GameUIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion
}
