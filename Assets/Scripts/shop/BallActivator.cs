using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class BallActivator : MonoBehaviour
{
    private Button activeteButton;
    private int index;

    private void Awake()
    {
        activeteButton = GetComponent<Button>();
        index = GetComponent<BuyChecker>().ballIndex;
    }

    private void OnEnable()
    {
        activeteButton.onClick.AddListener(Select);
    }

    private void OnDisable()
    {
        activeteButton.onClick.RemoveListener(Select);
    }

    public void Select()
    {
        DisableOtherObject();
        GetComponent<Image>().color = Color.green;
        YandexGame.savesData.ballIndex = index;
    }

    public void Desilect()
    {
        GetComponent<Image>().color = Color.white;
    }

    private void DisableOtherObject()
    {
        BallActivator[] activators = FindObjectsOfType<BallActivator>();

        foreach (BallActivator activator in activators)
        {
            activator.Desilect();
            activator.gameObject.GetComponent<buyBall>().CheckBuy();
        }
    }
}
