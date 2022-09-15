using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Cherater : MonoBehaviour
{
    [SerializeField] private GameObject cheaterCanvas;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);    
    }

    private void OnEnable()
    {
        YandexGame.CheaterVideoEvent += CheaterAd;
    }

    private void OnDisable()
    {
        YandexGame.CheaterVideoEvent -= CheaterAd;
    }

    private void CheaterAd()
    {
        cheaterCanvas.SetActive(true);
    }
}
