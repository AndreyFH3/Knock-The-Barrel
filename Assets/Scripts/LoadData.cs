using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class LoadData : MonoBehaviour
{
    [SerializeField] private GameObject disableObj;
    private void OnEnable()
    {
        YandexGame.GetDataEvent += GetData;
    }

    private void OnDisable()
    {   
        YandexGame.GetDataEvent -= GetData;
    }

    private void Start()
    {
        if(YandexGame.SDKEnabled) GetData();
    }

    private void GetData()
    {
        disableObj.SetActive(false);
    }
}
