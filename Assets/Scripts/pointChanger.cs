using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointChanger : MonoBehaviour
{

    [SerializeField] private folllowCamera _folllowCamera;
    [SerializeField] private Transform[] WatchPosition;
    [SerializeField] private GameObject finishGameObject;
    [SerializeField] private int MaxPoint;
    private int positionIndex = -1;

    private void SetPoint()
    {
       
    }

    private void FinishGame() => finishGameObject.SetActive(true);
}
