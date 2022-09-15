using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class AddSecondsForReward : MonoBehaviour
{
    [SerializeField] private BoxCounter _box;
    [SerializeField] private Timer timer;
    private Button AddSecButton;

    private void Awake()
    {
        AddSecButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        AddSecButton.onClick.AddListener(()=>YandexGame.RewVideoShow(1));
        YandexGame.CloseVideoEvent += AddSeconds;
    }

    private void OnDisable()
    {
        AddSecButton?.onClick.RemoveAllListeners();
        YandexGame.CloseVideoEvent -= AddSeconds;
    }


    private void AddSeconds(int index)
    {
        int secondsAddToTimer = (_box.boxCount - _box.destroyedBox) * 5;
        timer.AddSeconds(secondsAddToTimer);
    }
}
