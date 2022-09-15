using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

enum moneyUpgradeType { withText = 1, withoutText = 2 };

public class BonusMoney : MonoBehaviour
{
    [SerializeField] private moneyUpgradeType _moneyUpgradeType;
    [Header("Double Money in game")]
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private BoxCounter _boxCounter;

    [Header("Add 50 money In Menu")]
    [SerializeField] private GameObject _AddMoneyGO;

    private Button addMoneyButton;

    private void OnEnable()
    {
        YandexGame.CloseVideoEvent += AddMoney;
        addMoneyButton = GetComponent<Button>();
        addMoneyButton.onClick.AddListener(() => YandexGame.RewVideoShow(50));
    }

    private void OnDisable()
    {
        YandexGame.CloseVideoEvent -= AddMoney;
    }

    private void AddMoney(int value)
    {
        if (_moneyUpgradeType == moneyUpgradeType.withText)
        {
            int money = _boxCounter.moneyForComplete;
            moneyText.text = $"+{money * 2} монет";
            addMoneyButton.gameObject.SetActive(false);
            YandexGame.savesData.money += money;
        }
        else
        {
            YandexGame.savesData.money += 50;
            _AddMoneyGO.SetActive(true);
        }
        YandexGame.SaveProgress();
    }


}
