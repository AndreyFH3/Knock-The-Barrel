using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSelelected : MonoBehaviour
{
    [SerializeField] private Sprite[] BallSpriteArray;
    private int ballIndex;

    private void Start()
    {
        ballIndex = YG.YandexGame.savesData.ballIndex;
        BallSelect();
    }

    private void BallSelect() =>
        GetComponent<SpriteRenderer>().sprite = BallSpriteArray[ballIndex];
    
}
