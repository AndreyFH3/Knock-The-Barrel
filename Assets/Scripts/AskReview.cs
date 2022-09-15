using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class AskReview : MonoBehaviour
{
    [SerializeField] private Button HideBtn;
    [SerializeField] private GameObject ShowAsk;
    [SerializeField] private float timeToshow = 180;
    
    private bool canShow = false;
    private bool canCalculate = false;
    private float timeCalculated;

    private void OnEnable()
    {

        canCalculate = true;
        if (!YandexGame.savesData.isAskedReview)
        {
            DontDestroyOnLoad(gameObject);
        }
        else if (YandexGame.savesData.isAskedReview) 
        {
            Destroy(gameObject);
        }
        else if (canShow)
        {
            ShowAsk.SetActive(true);
        }
        HideBtn.onClick.AddListener(ChangeValue);
    }

    private void OnDisable()
    {
        HideBtn.onClick.RemoveListener(ChangeValue);
    }

    private void ChangeValue() 
    { 
        YandexGame.savesData.isAskedReview = true;
        Application.OpenURL("https://yandex.ru/games/app/195304");
    }

    void Update()
    {
        if (!canCalculate) return;

        timeCalculated += Time.deltaTime;
        if(timeCalculated >= timeToshow)
        {
            timeCalculated = 0;
            canCalculate = false;   
        }
    }
}
