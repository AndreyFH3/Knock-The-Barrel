using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class desktop : MonoBehaviour
{
    private void Awake()
    {
        if(YandexGame.EnvironmentData.isDesktop)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
