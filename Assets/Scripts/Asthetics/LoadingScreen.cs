using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Image loadingScreen;
    
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
                loadingScreen.color = color;
            }).SetDelay(2f).OnComplete(() =>
        {
            Time.timeScale = 1f;
            GameUIManager.Instance.StartGame();
            gameObject.SetActive(false);
        }).SetUpdate(true);
    }
}
