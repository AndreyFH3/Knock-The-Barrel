using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class buyBall : MonoBehaviour
{
    [SerializeField] private Sprite ball;
    [SerializeField] GameObject priceObject;
    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] private Image ballImg;
    [SerializeField] private ShowMoney moneyShow;

    private static int price => 100 + (50  * allCount);

    private BuyChecker _buyChecker;
    private Button buyButton;
    private int index;
    
    private static int allCount { get 
        {
            int counter = 0;
            foreach (bool isOpen in YandexGame.savesData.ballOpen)
            {
                if(isOpen)
                    counter++;
            }
            return counter;
        } 
    }

    private void Awake()
    {
        buyButton = GetComponent<Button>();
        _buyChecker = GetComponent<BuyChecker>();
        index = _buyChecker.ballIndex;
    }

    private void OnEnable()
    {
        buyButton.onClick.AddListener(Buy);
        textUpdate();
    }

    private void OnDisable()
    {
        buyButton.onClick.RemoveListener(Buy);
    }

    private void textUpdate()
    {
        priceText.text = $"{price}";

    }

    private void Buy()
    {
        Bought();
        YandexGame.savesData.money -= price;
        YandexGame.savesData.ballOpen[index] = true;
        moneyShow.UpdateMoneytext();
        AllCheckBuy();
        this.enabled = false;
    }


    private void AllCheckBuy()
    {
        buyBall[] balls = FindObjectsOfType<buyBall>();
        foreach(buyBall ball in balls)
        {
            ball.CheckBuy();
            ball.textUpdate();
        }
    }

    public void CheckBuy()
    {
        if (YandexGame.savesData.ballOpen[index]) return;
        if (YandexGame.savesData.money >= price)
        {
            buyButton.interactable = true;
        }
        else
            buyButton.interactable = false;
    }

    public void Bought()
    {
        ballImg.sprite = ball;
        priceObject.SetActive(false);
    }
}
