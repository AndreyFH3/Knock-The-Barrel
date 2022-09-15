using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class ShowMoney : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    private void Start()
    {
        UpdateMoneytext();
    }

    public void UpdateMoneytext()
    {
        moneyText.text = $"{YandexGame.savesData.money}";
    }
}
