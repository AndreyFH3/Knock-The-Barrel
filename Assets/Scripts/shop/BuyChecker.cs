using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using YG;

public class BuyChecker : MonoBehaviour
{
    public int ballIndex;

    private buyBall _buyBall;
    private BallActivator _ballActivator;


    private void Start()
    {
        _buyBall = GetComponent<buyBall>();
        _ballActivator = GetComponent<BallActivator>();
        YandexGame.savesData.ballOpen[0] = true;
        if (YandexGame.savesData.ballOpen[ballIndex] || ballIndex == 0)
        {
            _buyBall.Bought();
            _buyBall.enabled = false;

            if (YandexGame.savesData.ballIndex == ballIndex)
            {
                _ballActivator.Select();
            }
        }
        else
        {
            _buyBall.CheckBuy();
        }

    }

    private void OnDisable()
    {
        YandexGame.SaveProgress();
    }
}
