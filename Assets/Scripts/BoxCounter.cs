using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using YG;
using UnityEngine.SceneManagement;

public class BoxCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI boxCountText;
    [SerializeField] private GameObject WinCanvas;
    [SerializeField] private Ball _ball;
    [SerializeField] private throwBall _throwBall;
    [SerializeField] private TextMeshProUGUI completeLevelInfo;
    [SerializeField] private TextMeshProUGUI plusMoney;

    private bool isWin = false;
    public int moneyForComplete;//10, 20, 30, 40, 50.... 50.
    
    public int boxCount { get => _boxCount; 
        set { 
                if (_boxCount != value) {
                {
                    _boxCount = value;
                    UpdateText();
                }
            } 
        } 
    }
    public int destroyedBox { get => _destroyedBox; 
        set {  
            _destroyedBox = value;
            UpdateText();
            CheckWin();
        }
    }
    
    private int _boxCount = 0;
    private int _destroyedBox = 0;

    private void UpdateText()
    {
        boxCountText.text = $"{_destroyedBox} / {_boxCount}";
    }

    private void CheckWin()
    {
        isWin = destroyedBox >= boxCount;
        if (isWin)
        {
            WinCanvas.SetActive(true);
            DisableObjects(false);

            YandexGame.savesData.money += moneyForComplete;

            completeLevelInfo.text = $"Уровень {++YandexGame.savesData.maxLevel} пройден!";
            plusMoney.text = $"+{moneyForComplete} монет";

            int lastLevel = ++YandexGame.savesData.LevelIndexLoad;

            if(lastLevel >= SceneManager.sceneCountInBuildSettings)
            {
                YandexGame.savesData.LevelIndexLoad = 6;
            }
            YandexGame.NewLeaderboardScores("BestPlayer", YandexGame.savesData.maxLevel);
            YandexGame.SaveProgress();
        }
    }

    public void DisableObjects(in bool isDisable)
    {
        GetComponent<Timer>().enabled = isDisable;
        _ball.DesactiveRb();
        _ball.enabled = isDisable;
        _throwBall.enabled = isDisable;
    }
}
