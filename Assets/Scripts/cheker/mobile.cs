using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class mobile : MonoBehaviour
{
    private void Awake()
    {
        if (YandexGame.EnvironmentData.isMobile || YandexGame.EnvironmentData.isTablet)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
