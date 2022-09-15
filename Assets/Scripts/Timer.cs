using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timerInSeconds;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject loseCanvas;

    void Update()
    {
        timerInSeconds -= Time.deltaTime;

        if (timerInSeconds >= 0)
        {
            float minutes = timerInSeconds / 60;
            float seconds = timerInSeconds % 60;
            string secs = ((int)seconds).ToString();
            timerText.text = $"Времени осталось: {(int)minutes}:{(secs.Length > 1 ? secs : string.Concat("0", secs))}";
        }
        else
        {
            loseCanvas.SetActive(true);
            GetComponent<BoxCounter>().DisableObjects(false);
        }
    }

    public void AddSeconds(in int seconds)
    {
        timerInSeconds += seconds;
        loseCanvas.SetActive(false);
        GetComponent<BoxCounter>().DisableObjects(true);
    }
}
