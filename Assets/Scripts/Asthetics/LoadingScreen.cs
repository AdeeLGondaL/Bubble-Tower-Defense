using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Image loadingScreen, logoBG, logo, loadingText;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        FadeOut();
    }

    void FadeOut()
    {
        DOVirtual.Color(new Color(0.9607844f, 0.572549f, 0.145098f, 1f),
            new Color(0.9607844f, 0.572549f, 0.145098f, 0f), 3f, color =>
            {
                loadingText.color = logo.color = logoBG.color = new Color(1f, 1f, 1f, color.a);
                loadingScreen.color = color;
            }).SetDelay(2f).OnComplete(() =>
        {
            Time.timeScale = 1f;
            GameUIManager.Instance.StartGame();
            gameObject.SetActive(false);
        }).SetUpdate(true);
    }
}
