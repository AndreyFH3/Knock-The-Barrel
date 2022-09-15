using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trajectory : MonoBehaviour
{
    [SerializeField] private int dotsNumber;
    [SerializeField] private GameObject dotsParent;
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private float dotSpacing;
    [SerializeField, Range(0.01f,0.3f)] private float dotMinScale;
    [SerializeField, Range(0.3f, 0.7f)] private float dotMaxScale;


    private Transform[] dotsList;
    private float timeStamp;
    private Vector2 pos;

    private void Start()
    {
        PrepareDots();
        Hide();
    }

    public void Show()
    {
        dotsParent.SetActive(true);
    }
        
    public void Hide()
    {
        dotsParent.SetActive(false);
    }

    public void UpdateDots(Vector3 ballPosition, Vector2 forceApplied)
    {
        timeStamp = dotSpacing;
        for(int i = 0; i<dotsNumber; i++)
        {
            pos.x = (ballPosition.x + forceApplied.x * timeStamp);
            pos.y = (ballPosition.y + forceApplied.y * timeStamp)
                - (Physics2D.gravity.magnitude * timeStamp * timeStamp) / 2;


            dotsList[i].position = pos;
            timeStamp += dotSpacing;
        }
    }

    private void PrepareDots()
    {
        dotsList = new Transform[dotsNumber];
        dotPrefab.transform.localScale = Vector3.one * dotMaxScale;
        float scale = dotMaxScale;
        float scaleFactor = scale / dotsNumber;
        for(int i = 0; i < dotsNumber; i++)
        {
            dotsList[i] = Instantiate(dotPrefab, dotsParent.transform).transform;
            dotsList[i].localScale = Vector3.one * scale;
            if (scale > dotMinScale) 
                scale -= scaleFactor;
        }

    }



}
